using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Red;
using ZedGraph;

namespace ProjectsManager
{
    public partial class ChartForm : Form
    {
        String sectionsQuery = "Select Name from Sections";
        String studentsPerYearQuery = @"SELECT count( s.[Id]) 
  FROM ([Students] s inner join Groups g on s.GroupId=g.Id)
  inner join Sections sec on g.SectionId=sec.Id
  where sec.Name='{2}' 
  and (s.EnterDate <= '{0}-09-01 00:00:00.000' and '{1}-09-01 00:00:00.000' <= s.GraduateDate )";
        String minYearQuery = "SELECT min([EnterDate]) FROM [Students] ";
        string maxYearQuery = "SELECT max([GraduateDate]) FROM [Students]";
        private RedContext context;
        private int minYear,maxYear;
        private string graphLable = "Кількість студентів за роками";
        private string barLable = "Секція {0}";

        public ChartForm(RedContext context)
        {
            InitializeComponent();
            this.context = context;
            var sectTable = context.Provider.ExecuteSelectCommand(sectionsQuery);
            comboBox1.DisplayMember = sectTable.Columns[0].ColumnName;
            comboBox1.DataSource = sectTable;
            minYear = DateTime.Parse(context.Provider.ExecuteSelectCommand(minYearQuery).Rows[0][0].ToString()).Year;
            maxYear = DateTime.Parse(context.Provider.ExecuteSelectCommand(maxYearQuery).Rows[0][0].ToString()).Year;
            zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;
            zedGraphControl1.GraphPane.Title.Text = graphLable;
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Навчальні роки";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Кількість студентів";
            zedGraphControl1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            double[] years = new double[maxYear - minYear+1];
            for (int i = 0; i < years.Count(); i++)
            {
                years[i] = minYear + i;
            }

            double[] count = new double[years.Length-1];
            string[] lables = new string[years.Length-1];
            for (int i = 0; i < years.Length-1; i++)
            {
                count[i] = double.Parse(context.Provider.ExecuteSelectCommand(
                    string.Format(studentsPerYearQuery, years[i], years[i + 1], comboBox1.Text)).Rows[0][0].ToString());
                lables[i] = string.Format("{0}-{1}",years[i],years[i+1]);
            }
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = lables;
            var random = new Random();
            var color = Color.FromArgb(random.Next(255),random.Next(255),random.Next(255));
            zedGraphControl1.GraphPane.AddBar(String.Format(barLable,comboBox1.Text), years, count, color);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
    }
}


