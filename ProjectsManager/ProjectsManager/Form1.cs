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
    public partial class Form1 : Form
    {
        private RedContext context;
        private RedDataSet dataSet;
        private DBConfig config;

        private string curentTableName;
        private string curentViewName;

        public Form1(DBConfig config)
        {
            this.config = config;
            InitializeComponent();
            context = new RedContext() {Provider = new RedDBProvider(config.ConnectionString)};
            InitForm();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void InitForm()
        {
            dataSet = new RedDataSet();
            foreach (var t in config.Tables)
            {
                dataSet.AddTable(t.query, t.name, context);
                if (t.Comboboxes != null)
                {
                    foreach (var c in t.Comboboxes)
                    {
                        dataSet.tables[t.name].AddComboBox(c.name, new RedComboBox(c.query, c.name));
                    }
                }
                if(t.Columns!=null)
                {
                    foreach (var c in t.Columns)
                    {
                        dataSet.tables[t.name].AddColumnAliasHere(c.Name, c.Alias);
                    }
                }
                lstTables.Items.Add(t.name);
            }
            foreach (var r in config.Requests)
            {
               dataSet.AddView(r.query, r.name, r.desc, context);
               if (r.Comboboxes != null)
               {
                   foreach (var c in r.Comboboxes)
                   {
                       dataSet.views[r.name].AddComboBox(c.name, new RedComboBox(c.query, c.name));
                   }
               }
               lstReqs.Items.Add(r.name);
            }
        }

        private void lstTables_DoubleClick(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            {
                curentTableName = lstTables.SelectedItem.ToString();
                dataSet.tables[lstTables.SelectedItem.ToString()].Refresh(context);
                SetDataSource(dataSet.tables[lstTables.SelectedItem.ToString()]);
            }
        }

        private void SetDataSource(RedTable table)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            foreach(DataColumn col in table.Columns)
            {
                if (table.ComboBoxes.ContainsKey(col.ColumnName))
                {
                    var combox = table.ComboBoxes[col.ColumnName];
                    DataTable comboTable = combox.GetValues(context);
                    dataGridView1.Columns.Add(new DataGridViewComboBoxColumn()
                                                  {
                                                      Name = col.ColumnName,
                                                      HeaderText = table.GetColumnAliase(col.ColumnName),
                                                      DataSource = comboTable,
                                                      ValueMember = comboTable.Columns[0].ColumnName,
                                                      DisplayMember = (comboTable.Columns.Count > 1)
                                                                          ?comboTable.Columns[1].ColumnName
                                                                          :comboTable.Columns[0].ColumnName,
                                                      DataPropertyName = col.ColumnName
                                                  });
                }
                else
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = col.ColumnName, DataPropertyName=col.ColumnName, 
                        HeaderText = table.GetColumnAliase(col.ColumnName)});
                
            }
            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataSet.tables[curentTableName].Update(context);
        }

        private void lstReqs_DoubleClick(object sender, EventArgs e)
        {
            if (lstReqs.SelectedItem != null)
            {
                try
                {
                    curentViewName = lstReqs.SelectedItem.ToString();
                    List<string> ps = new List<string>();
                    if (dataSet.views[curentViewName].ComboBoxes != null &&
                        dataSet.views[curentViewName].ComboBoxes.Count != 0)
                    {
                        ViewForm vf = new ViewForm(dataSet.views[curentViewName].GetComboboxes(), context);
                        vf.ShowDialog();
                        if (vf.buttonOkClicked)
                        {
                            dataGridView1.AutoGenerateColumns = true;
                            ps = vf.parametrs;
                            dataGridView1.Columns.Clear();
                            dataGridView1.DataSource = dataSet.views[curentViewName].GetViewData(ps.ToArray(), context);
                            dataGridView1.ReadOnly = true;
                        }
                    }
                    else
                    {
                        dataGridView1.Columns.Clear();
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = dataSet.views[curentViewName].GetViewData(ps.ToArray(), context);
                    }
                }catch(Exception ex)
                {
                    Message("Ошибка выполнения запроса. Проверте правильность параметров.");
                }
            }
        }

        private void Message(string p)
        {
            MessageBox.Show(p, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Message("Несовпадение типов данных. Проверте правильность ввода данных.");
        }

        private void описаниеЗапорсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message(dataSet.views[lstReqs.SelectedItem.ToString()].Descritpion);
        }

        private void lstReqs_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Point pnt = new Point(e.X, e.Y);
                lstReqs.SelectedIndex = lstReqs.IndexFromPoint(pnt);
            }
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message(@"Информационная система предназначена для управления проэктами. ИС позволяет наблюдать, изменять и вносить новые корективы в базу данных. 
 
Чтобы открыть таблицу: двойной клик на названии таблицы в списке 'Таблицы'

При внесении изменений в таблицу необходимо сохранить изменения: Действие -> Сохранить

Чтобы просмотреть информацую о запросе: правый клик на названии запроса в списке 'Запросы'

Чтобы выполнить запрос: двойной клик на названии запроса в списке 'Запросы'");
        }


    }
}
