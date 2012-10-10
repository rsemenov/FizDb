using System;
using System.Collections.Generic;
using System.Data;

namespace Red
{
    public class RedComboBox
    {
        public string query;
        public String Name { get; private set; }

        public RedComboBox(string query, string name)
        {
            this.query = query;
            Name = name;
        }

        public DataTable GetValues(RedContext context)
        {
            var table = context.Provider.ExecuteSelectCommand(query);
            return table;
        }
    }
}