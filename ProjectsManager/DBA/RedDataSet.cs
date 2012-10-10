using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Red
{
    public class RedDataSet
    {
        public Dictionary<string, RedTable> tables { get; set; }
        public Dictionary<string, RedView> views { get; set; }
        
        public void AddTable(string query, string name, RedContext context)
        {
            tables.Add(name, new RedTable(name, query, context));
        }

        public void AddView(string query, string name, string description, RedContext context)
        {
            views.Add(name, new RedView(name, query, description));
        }

        public RedDataSet()
        {
            tables = new Dictionary<string, RedTable>();
            views = new Dictionary<string, RedView>();
        }


    }


    public class RedContext
    {
        public RedContext()
        {
            
        }
        public RedDBProvider Provider {get;set;}
    }

/*    public class RedControl
    {
        public RedDBProvider provider;
    }*/
}
