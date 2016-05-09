using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.Db
{
    [Serializable()]
    [DefaultPropertyAttribute("Connection")]
    [DbNodeAttribute(ImageIndex=0)]
    [XmlRoot("Database")]
    public class Database : ContextObject,ICloneable
    {
        //private Connection connection=new Connection(this);
        private DatabaseType databaseType = DatabaseType.SQLServer2000;

        public Database(ContextObject owner)
            :base(owner)
        {
            Connection = new Connection(this);

            Tables = new ContextObjectList<TableInfo>(this);
            Views = new ContextObjectList<ViewInfo>(this);
        }

        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [DbNodeInvisibleAttribute()]
        [XmlElement("Connection")]
        public Connection Connection
        {
            get;
            set;
        }

        [CategoryAttribute("设计"), DefaultValueAttribute(DatabaseType.SQLServer2000)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("DatabaseType")]
        public DatabaseType DatabaseType
        {
            get { return databaseType; }
            set 
            { 
                databaseType = value;
                NotifyPropertyChanged(this, "DatabaseType");
            }
        }

        [BrowsableAttribute(false)]
        [DbNodeAttribute(Text = "Tables", ImageIndex = 1)]
        [XmlElement("Tables")]
        [ReadOnly(true)]
        public List<TableInfo> Tables
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        [DbNodeAttribute(Text="Views",ImageIndex=1)]
        [XmlElement("Views")]
        [ReadOnly(true)]
        public List<ViewInfo> Views
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Connection.InitialCatalog+"/"+Connection.DataSource;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
