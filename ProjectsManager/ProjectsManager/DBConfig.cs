using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProjectsManager
{
    [Serializable]
    [XmlRoot("DBConfig")]
    public class DBConfig
    {
        [XmlElement("ConnectionString")]
        public string ConnectionString { get; set; }

        [XmlArray("Tables")]
        [XmlArrayItem("Table")]
        public ConfigTable[] Tables { get; set; }

        [XmlArray("Requests")]
        [XmlArrayItem("Request")]
        public ViewControl[] Requests { get; set; }

    }

    public class ConfigControl
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("query")]
        public string query { get; set; }

        [XmlAttribute("desc")]
        public string desc { get; set; }
    }

    public class ConfigTable : ConfigControl
    {
        [XmlArray("ComboBoxes")]
        [XmlArrayItem("ComboBox")]
        public ConfigControl[] Comboboxes { get; set; }

        [XmlArray("Columns")]
        [XmlArrayItem("Column")]
        public ConfigColumn[] Columns { get; set; }

        [XmlElement("SearchQuery")]
        public SearchQuery SearchQuery { get; set; }
    }

    public class SearchQuery
    {
        [XmlAttribute("query")]
        public string Query { get; set; }
    }

    public class ViewControl:ConfigTable
    {
        /*[XmlArray("Parameters")]
        [XmlArrayItem("Parameter")]
        public string[] parameters { get; set; }*/
    }

    public class ConfigColumn
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("alias")]
        public string Alias { get; set; }
    }
}
