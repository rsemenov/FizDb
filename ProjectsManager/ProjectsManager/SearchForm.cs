using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Red;

namespace ProjectsManager
{
    public partial class SearchForm : Form
    {
        List<string> tables;
        public event EventHandler<SearchClickedArgs> SearchClicked;

        public SearchForm(RedDataSet dataset)
        {
            InitializeComponent();
            tables = dataset.tables.Where(pair => !string.IsNullOrEmpty(pair.Value.SearchQuery)).Select(pair => pair.Key).ToList();
            comboBox1.DataSource = tables;
            comboBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;
            if (SearchClicked != null)
            {
                SearchClicked.Invoke(this, new SearchClickedArgs() { SearchWord = textBox1.Text.Replace(" ",""), TableName = comboBox1.Text });
             }
        }
    }

    public class SearchClickedArgs : EventArgs
    {
        public string TableName { get; set; }
        public string SearchWord { get; set; }
    }
}
