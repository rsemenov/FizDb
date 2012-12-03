using System;
using System.Drawing;
using System.Linq;
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

        private double[] years;
        private double[] count;

        private void button1_Click(object sender, EventArgs e)
        {            
            years = new double[maxYear - minYear+1];
            for (int i = 0; i < years.Count(); i++)
            {
                years[i] = minYear + i;
            }

            count = new double[years.Length-1];
            string[] lables = new string[years.Length-1];
            for (int i = 0; i < years.Length-1; i++)
            {
                count[i] = double.Parse(context.Provider.ExecuteSelectCommand(
                    string.Format(studentsPerYearQuery, years[i], years[i + 1], comboBox1.Text)).Rows[0][0].ToString());
                lables[i] = string.Format("{0}",years[i]);
            }
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = lables;
            var random = new Random();
            var color = Color.FromArgb(100,random.Next(255),random.Next(255),random.Next(255));
            zedGraphControl1.GraphPane.AddBar(String.Format(barLable,comboBox1.Text), years, count, color);
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int period;
            if(!int.TryParse(textBox1.Text, out period))
                MessageBox.Show("Число років прогнозування має бути цілим");
            IForecast lineFc;

            if (count[0] < count[1])
                lineFc = new LiniarForecast();
            else
                lineFc = new LiniarDownForecast();

            double[] _years;
            double[] _counts;
            lineFc.MakeForecast(years, count, out _years, out _counts, period );
            string[] lables = new string[_years.Length];
            for (int i = 0; i < _years.Length; i++)
            {
                lables[i] = string.Format("{0}", _years[i]);
            }
            double[] bars = new double[_counts.Length];
            double[] forecastyears = new double[_counts.Length];
            for (int i = _counts.Length - period; i < _counts.Length; i++)
            {
                forecastyears[i] = _years[i];
                bars[i] = _counts[i];
            }
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = lables;
            zedGraphControl1.GraphPane.AddBar("Лінійний прогноз", forecastyears, bars, Color.FromArgb(100, 12, 22, 200));
            zedGraphControl1.GraphPane.AddCurve("Лінійний прогноз", _years, _counts, Color.BlueViolet);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int period;
            if (!int.TryParse(textBox1.Text, out period))
                MessageBox.Show("Число років прогнозування має бути цілим");
            IForecast lineFc = new ExpForecast();
            double[] _years;
            double[] _counts;
            lineFc.MakeForecast(years, count, out _years, out _counts, period);
            string[] lables = new string[_years.Length];
            for (int i = 0; i < _years.Length; i++)
            {
                lables[i] = string.Format("{0}", _years[i]);
            } 
            double[] bars = new double[_counts.Length];
            double[] forecastyears = new double[_counts.Length];
            for (int i = _counts.Length - period; i < _counts.Length; i++)
            {
                forecastyears[i] = _years[i];
                bars[i] = _counts[i];
            }
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = lables;
            zedGraphControl1.GraphPane.AddBar("Експоненційний прогноз", forecastyears, bars, Color.FromArgb(100, 210, 2, 10));
            zedGraphControl1.GraphPane.AddCurve("Експоненційний прогноз", _years, _counts, Color.Red);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int period;
            if (!int.TryParse(textBox1.Text, out period))
                MessageBox.Show("Число років прогнозування має бути цілим");
            IForecast lineFc = new ParabolForecast();
            double[] _years;
            double[] _counts;
            lineFc.MakeForecast(years, count, out _years, out _counts, period);
            string[] lables = new string[_years.Length];
            for (int i = 0; i < _years.Length; i++)
            {
                lables[i] = string.Format("{0}", _years[i]);
            }
            double[] bars = new double[_counts.Length];
            double[] forecastyears = new double[_counts.Length];
            for(int i = _counts.Length-period;i<_counts.Length;i++)
            {
                forecastyears[i] = _years[i];
                bars[i] = _counts[i];
            }
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = lables;
            zedGraphControl1.GraphPane.AddCurve("Параболічний прогноз", _years, _counts, Color.Green);
            zedGraphControl1.GraphPane.AddBar("Параболічний прогноз", forecastyears, bars, Color.FromArgb(100, 12,230,13));
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int period;
            if (!int.TryParse(textBox1.Text, out period))
                MessageBox.Show("Число років прогнозування має бути цілим");
            IForecast lineFc = new HiperbolForecast();
            double[] _years;
            double[] _counts;
            lineFc.MakeForecast(years, count, out _years, out _counts, period);
            string[] lables = new string[_years.Length];
            for (int i = 0; i < _years.Length; i++)
            {
                lables[i] = string.Format("{0}", _years[i]);
            }
            double[] bars = new double[_counts.Length];
            double[] forecastyears = new double[_counts.Length];
            for (int i = _counts.Length - period; i < _counts.Length; i++)
            {
                forecastyears[i] = _years[i];
                bars[i] = _counts[i];
            }
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = lables;
            zedGraphControl1.GraphPane.AddBar("Гіперболічний прогноз", forecastyears, bars, Color.FromArgb(100, 210, 221, 120));
            zedGraphControl1.GraphPane.AddCurve("Гіперболічний прогноз", _years, _counts, Color.PowderBlue);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }


    }
}


