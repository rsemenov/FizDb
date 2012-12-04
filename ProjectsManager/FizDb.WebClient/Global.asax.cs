using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Serialization;
using Red;

namespace FizDb.WebClient
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            XmlSerializer serializer = new XmlSerializer(typeof(DBConfig));
            var conf = new DBConfig();
            using (var stream = File.OpenRead(@"d:\TK\Lesia\LabaBoiko\FizDb\ProjectsManager\FizDb.WebClient\bin\DBConfig.xml"))
            {
                conf = (DBConfig)serializer.Deserialize(stream);
            }
            var context = new RedContext() { Provider = new RedDBProvider(conf.ConnectionString) };
            Container.Context = context;
            Container.Dataset = GetDataSet(conf, context);
        }

        private Red.RedDataSet GetDataSet(DBConfig config, RedContext context)
        {
            var dataSet = new RedDataSet();
           
            foreach (var t in config.Tables)
            {
                dataSet.AddTable(t.query, t.name, t.SearchQuery==null? null: t.SearchQuery.Query, context);
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
            }

            return dataSet;
        }
    }
}