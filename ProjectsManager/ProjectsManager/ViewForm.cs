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
    public partial class ViewForm : Form
    {
        public List<string> parametrs;
        
        public ViewForm(RedComboBox[] comboboxes, RedContext context)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            parametrs = new List<string>();
            InitGrid(comboboxes, context);
        }

        private void InitGrid(RedComboBox[] comboboxes, RedContext context)
        {
            foreach(RedComboBox cb in comboboxes)
            {
                var row = new DataGridViewRow();
                var c1 = new DataGridViewTextBoxCell();
                c1.Value = cb.Name;
                DataGridViewCell c2;
                if (cb.query.ToLowerInvariant() == "textedit")
                {
                    c2 = new DataGridViewTextBoxCell();
                    c2.Value = "";
                }
                else
                {
                    c2 = new DataGridViewComboBoxCell();
                    var t = cb.GetValues(context);
                    foreach (DataRow r in t.Rows)
                    {
                        (c2 as DataGridViewComboBoxCell).Items.Add(r[0].ToString());
                    }
                    (c2 as DataGridViewComboBoxCell).Value = (c2 as DataGridViewComboBoxCell).Items[0];
                }
                c2.ReadOnly = false;
                row.Cells.Add(c1);
                row.Cells.Add(c2);
                dataGridView1.Rows.Add(row);
            }
        }

        public bool buttonOkClicked = false;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dataGridView1.Rows)
            {
                parametrs.Add(r.Cells[1].Value.ToString());
            }
            buttonOkClicked = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эта форма предназначена для ввода параметров запроса. В левой колонке вы видите имя параметра, в правой - возможные значения.");
        }

    }
}
