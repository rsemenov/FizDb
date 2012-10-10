using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Red
{
    interface IRedComboboxed
    {
        Dictionary<string, RedComboBox> ComboBoxes { get; set; }

        DataTable GetColumnValues(string columnName, RedContext context);
        void AddComboBox(string name, RedComboBox checkBox);
        
    }
}
