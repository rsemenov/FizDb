using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FizDb.WebClient.Models
{
    public class DatabaseModel
    {
        public List<string> Tables { get; set; }
        public TableViewModel CurrentTable { get; set; }
        public Red.RedDataSet DataSet { get; set; }
    }

    public class TableViewModel
    {
        public List<string> Columns { get; set; }
        public List<string[]> Rows { get; set; }

        public TableViewModel()
        {
            Columns = new List<string>();
            Rows = new List<string[]>();
        }

        public static TableViewModel Create(Red.RedTable table)
        {
            var tvm = new TableViewModel();
            Dictionary<string, DataTable> comboboxes = new Dictionary<string, DataTable>();
            foreach(DataColumn col in table.Columns)
            {
                if (col.ColumnName != "Id")
                    tvm.Columns.Add(table.GetColumnAliase(col.ColumnName));
                
                if (table.ComboBoxes.ContainsKey(col.ColumnName))
                    {
                        var combox = table.ComboBoxes[col.ColumnName];
                        var t = combox.GetValues(Container.Context);
                        comboboxes.Add(col.ColumnName, t);
                    }
            }

            foreach (DataRow r in table.Rows)
            {
                List<string> items = new List<string>();
                for(int i = 0; i<r.ItemArray.Length;i++)
                {
                    if (table.Columns[i].ColumnName != "Id")
                    {
                        if (comboboxes.ContainsKey(table.Columns[i].ColumnName))
                        {
                            var rows = comboboxes[table.Columns[i].ColumnName].Rows.Cast<DataRow>();
                            var rr = rows.FirstOrDefault(ro => ro.ItemArray[0].ToString() == r.ItemArray[i].ToString());
                            if (rr != null)
                            {
                                items.Add(rr.ItemArray.Length > 1
                                              ? rr.ItemArray[1].ToString()
                                              : rr.ItemArray[0].ToString());
                            }
                            else
                                items.Add(r.ItemArray[i].ToString());
                        }
                        else
                            items.Add(r.ItemArray[i].ToString());
                    }
                }
                tvm.Rows.Add(items.ToArray());
            }
            return tvm;
        }
    }
}