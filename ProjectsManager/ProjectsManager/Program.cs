using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProjectsManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            XmlSerializer serializer = new XmlSerializer(typeof(DBConfig));
            var conf = new DBConfig();
            using (var stream = File.OpenRead("DBConfig.xml"))
            {
                conf = (DBConfig)serializer.Deserialize(stream);
            }
            Application.Run(new Form1(conf));
        }
    }
}
