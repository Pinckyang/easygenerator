using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.DB
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlInclude(typeof(TableInfo))]
    [XmlInclude(typeof(ViewInfo))]
    public abstract class EntityInfo : ContextObject
    {
        public EntityInfo(ContextObject owner)
            :base(owner)
        {
            Columns= new ContextObjectList<ColumnInfo>(this);
            this.Schema = "dbo";
        }


        [CategoryAttribute("数据库")]
        [DefaultValueAttribute("")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Name")]
        public virtual string Name
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [DefaultValueAttribute("")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Caption")]
        public virtual string Caption
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [DefaultValueAttribute("")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Schema")]
        public string Schema
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [BrowsableAttribute(false)]
        [XmlElement("Columns")]
        public virtual List<ColumnInfo> Columns
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
