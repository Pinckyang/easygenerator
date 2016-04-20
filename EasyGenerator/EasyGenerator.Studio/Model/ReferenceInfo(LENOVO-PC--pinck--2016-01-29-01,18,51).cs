using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlInclude(typeof(PrimaryKeyReferenceInfo))]
    [XmlInclude(typeof(ForeignKeyReferenceInfo))]
    [XmlRoot("ReferenceInfo")]
    [XmlType(Namespace = "")]
    public abstract class ReferenceInfo : ContextObject, ICloneable, IXmlSerializable
    {
        private string name;
        private string tableName;
        private string columnName;
        private EntityInfo referenceTable=null;
        private string referenceTableName;
        private string referenceColumnName;



        [CategoryAttribute("数据库"), BrowsableAttribute(true), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement("Name")]
        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                NotifyPropertyChanged(this, "Name");
            }
        }

        [CategoryAttribute("数据库"), BrowsableAttribute(true), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement("TableName")]
        public string TableName
        {
            get { return tableName; }
            set 
            { 
                tableName = value;
                NotifyPropertyChanged(this, "TableName");
            }
        }

        [CategoryAttribute("数据库"), BrowsableAttribute(true), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement("ColumnName")]
        public string ColumnName
        {
            get { return columnName; }
            set 
            { 
                columnName = value;
                NotifyPropertyChanged(this, "ColumnName");
            }
        }

        [CategoryAttribute("数据库"), BrowsableAttribute(false), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlIgnore]
        public virtual EntityInfo ReferenceTable
        {
            get { return referenceTable; }
            set 
            {
                referenceTable = value;
                referenceTable.Owner = this;
                NotifyPropertyChanged(this, "ReferenceTable");
            }
        }

        [CategoryAttribute("数据库"), BrowsableAttribute(true), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement("ReferenceTableName")]
        public string ReferenceTableName
        {
            get { return referenceTableName; }
            set 
            { 
                referenceTableName = value;
                NotifyPropertyChanged(this, "ReferenceTableName");
            }
        }

        [CategoryAttribute("数据库"), BrowsableAttribute(true), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement("ReferenceColumnName")]
        public string ReferenceColumnName
        {
            get { return referenceColumnName; }
            set 
            { 
                referenceColumnName = value;
                NotifyPropertyChanged(this, "ReferenceColumnName");
            }
        }

        public abstract object Clone();
    }

    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 7)]
    [UiNodeAttribute(ImageIndex = 9)]
    [XmlRoot("ForeignKeyReferenceInfo")]
    [XmlType(Namespace = "")]
    public class ForeignKeyReferenceInfo : ReferenceInfo, ICloneable
    {
        [CategoryAttribute("数据库"), BrowsableAttribute(false), ReadOnly(true)]
        [UiNodeInvisibleAttribute()]
        public override EntityInfo ReferenceTable
        {
            get { return base.ReferenceTable; }
            set 
            { 
                base.ReferenceTable = value;
                
                NotifyPropertyChanged(this, "ReferenceTable");
            }
        }

       

        public override string ToString()
        {
            return string.Format("{0}({1}->[{2}:{3}])", this.Name, "Master", this.ReferenceTableName,this.ReferenceColumnName);
        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }



        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            this.Name = reader.ReadElementString("Name");
            this.ColumnName = reader.ReadElementString("ColumnName");
            this.ReferenceTableName = reader.ReadElementString("ReferenceTableName");
            this.ReferenceColumnName = reader.ReadElementString("ReferenceColumnName");
        }

        public void WriteXml(XmlWriter writer)
        {

            writer.WriteElementString("Name", this.Name);
            writer.WriteElementString("ColumnName", this.ColumnName);
            writer.WriteElementString("ReferenceTableName", this.ReferenceTableName);
            writer.WriteElementString("ReferenceColumnName", this.ReferenceColumnName);
        }
    }

    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 6)]
    [UiNodeAttribute(ImageIndex = 8)]
    public class PrimaryKeyReferenceInfo : ReferenceInfo, ICloneable
    {
        public override string ToString()
        {
            return string.Format("{0}({1}->[{2}:{3}])", this.Name, "Detail", this.ReferenceTableName, this.ReferenceColumnName);
        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
