using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Red;
using System.IO;
using System.Diagnostics;

namespace ProjectsManager
{
    public partial class StudentCompetitionReportGeneration : Form
    {
        private RedContext context;
        
        private string competQuery = @"SELECT c.Id as Id,
       c.Name as Name
  FROM ([Sportdb].[dbo].[Students] s inner join CompetitionsStudents cs on s.Id = cs.StudentId)
  inner join Competitions c on c.Id = cs.CompetitionId
WHERE cs.StudentId={0}";

        private string studQuery = "Select Id, Name From Students";

        private string reportQuery = @"SELECT s.[Name]
		,f.Name
		,sec.Name
		,g.Title
		,c.Name
		,c.StartDateTime
		,c.[Address]
        ,cs.Result
		,cs.Additional
  FROM 
  [Sportdb].[dbo].[Competitions] c inner join CompetitionsStudents cs on c.Id=cs.CompetitionId
  inner join Students s on cs.StudentId=s.Id
  inner join Faculties f on s.Faculty=f.Id
  inner join Groups g on g.Id=s.GroupId
  inner join Sections sec on sec.Id=g.SectionId
  where s.Id = {0} and c.Id={1}";

        public StudentCompetitionReportGeneration(RedContext context)
        {
            InitializeComponent();
            this.context = context;
            var students = context.Provider.ExecuteSelectCommand(studQuery);

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = students;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var report = File.ReadAllText(".\\Reports\\student_report.tmpl");
            var restable =
                context.Provider.ExecuteSelectCommand(string.Format(reportQuery, comboBox1.SelectedValue,
                                                                    comboBox2.SelectedValue));
            if(restable.Rows.Count>0)
            {
                object[] arr = restable.Rows[0].ItemArray;
                var result = string.Format(report, arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8]);
                Random r = new Random();
                var filename = string.Format(".\\Reports\\student_report{0}{1}{2}.html", comboBox1.SelectedValue,
                                             comboBox2.SelectedValue, r.Next(10000).ToString());
                
                File.AppendAllText(filename, result, Encoding.UTF8);
                Process p = new Process();
                p.StartInfo.FileName = filename;
                p.Start();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sid = (int)comboBox1.SelectedValue;
            var competitions = context.Provider.ExecuteSelectCommand(string.Format(competQuery, sid));
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";
            comboBox2.DataSource = competitions;
            comboBox2.Refresh();
        }
    }
}
