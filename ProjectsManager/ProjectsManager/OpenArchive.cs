using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProjectsManager
{
    public partial class OpenArchive : Form
    {
        private string archDir = "d:\\SportProject";
        public string SelectedFile { get; set; }
        public OpenArchive()
        {
            InitializeComponent();
            DirectoryInfo di = new DirectoryInfo(archDir);
            foreach (var f in di.GetFiles("*.mdf"))
            {
                comboBox1.Items.Add(f.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedFile = comboBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}
