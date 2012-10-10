using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;

namespace Red
{
    public class RedTable:DataTable,IRedComboboxed
    {
        private OleDbDataAdapter dataAdapter;
        public Dictionary<string, RedComboBox> ComboBoxes{get; set;}
        private string query;

        public RedTable(string tablename,string query, RedContext context):base(tablename)
        {
            this.query = query;
            context.Provider.OpenConnection();
            dataAdapter = new OleDbDataAdapter(query, context.Provider.Connection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(dataAdapter);
            FillAdapter(context);
            dataAdapter.UpdateCommand = builder.GetUpdateCommand();
            context.Provider.CloseConnection();
            ComboBoxes = new Dictionary<string, RedComboBox>();
        }

        public DataTable GetColumnValues(string columnName, RedContext context)
        {
            return ComboBoxes[columnName].GetValues(context);
        }

        public void AddComboBox(string name, RedComboBox checkBox)//addcheckboxhere!
        {
            ComboBoxes.Add(name, checkBox);
        }

        public int Update(RedContext context)
        {
            try
            {
                context.Provider.OpenConnection();
                return dataAdapter.Update(this);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                context.Provider.CloseConnection();
            }

        }

        public void Refresh(RedContext context)
        {
            this.Rows.Clear();
            FillAdapter(context);
        }

        private void FillAdapter(RedContext context)
        {
            context.Provider.OpenConnection();
            dataAdapter.Fill(this);
            context.Provider.CloseConnection();
        }
    }
}