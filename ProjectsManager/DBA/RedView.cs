using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Red
{
    public class RedView:IRedComboboxed
    {
        public string query;

        public List<string> parameters = new List<string>();
        
        private DataTable table;
        private string name;
        public string Descritpion {get; private set; }

        public RedView(string name, string query, string description, string[] parameters)
        {
            this.query = query;
            this.parameters.AddRange(parameters);
            this.name = name;
            Descritpion = description;
        }

         public RedView(string name, string query, string description)
         {
             this.query = query;
             this.name = name;
             ComboBoxes = new Dictionary<string, RedComboBox>();
             Descritpion = description;
         }

        public DataTable GetViewData(string[] parameters_, RedContext context)
         {
            string nq = query;
            try
            {
                nq = string.Format(query, parameters_);
            }catch(FormatException e)
            {
                throw new FormatException("Не коректные параметры. Вводите коректные параметры из выпадающего списка.",e);
            }
            table = context.Provider.ExecuteSelectCommand(nq);
            table.TableName = name;
            return table;
        }

        public RedComboBox[] GetComboboxes()
        {
            return ComboBoxes.Values.ToArray<RedComboBox>();
        }

        #region IRedComboboxed Members

        public Dictionary<string, RedComboBox> ComboBoxes{get;set;}

        public DataTable GetColumnValues(string columnName, RedContext context)
        {
            return ComboBoxes[columnName].GetValues(context);
        }

        public void AddComboBox(string name, RedComboBox comboBox)//addcheckboxhere!
        {
            ComboBoxes.Add(name, comboBox);
        }

        #endregion
    }
}
