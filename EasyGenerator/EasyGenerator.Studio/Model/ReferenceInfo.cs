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
using System.Diagnostics;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlInclude(typeof(PrimaryKeyReferenceInfo))]
    [XmlInclude(typeof(ForeignKeyReferenceInfo))]
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

        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            //Type type = Type.GetType(reader.GetAttribute("xsi:type"));
           // reader.Read();
           //// reader.ReadAttributeValue(
           // this.Name = reader.ReadElementString("Name");
           // this.ColumnName = reader.ReadElementString("ColumnName");
           // this.ReferenceTableName = reader.ReadElementString("ReferenceTableName");
           // this.ReferenceColumnName = reader.ReadElementString("ReferenceColumnName");
        }

        public virtual void WriteXml(XmlWriter writer)
        {

            writer.WriteElementString("Name", this.Name);
            writer.WriteElementString("ColumnName", this.ColumnName);
            writer.WriteElementString("ReferenceTableName", this.ReferenceTableName);
            writer.WriteElementString("ReferenceColumnName", this.ReferenceColumnName);
        }

        public abstract object Clone();
    }

    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 7)]
    [UiNodeAttribute(ImageIndex = 9)]
   // [XmlRoot(ElementName = "Reference", Namespace = "http://foo.bar")]
    [XmlType(TypeName = "ForeignKeyReferenceInfo")]
    public class ForeignKeyReferenceInfo : ReferenceInfo, ICloneable//,IXmlSerializable
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





        public override XmlSchema GetSchema()
        {
            return null;
        }

        public  override void ReadXml(XmlReader reader)
        {
            //Debug.WriteLine("======================");
            //reader.Read();
            //this.Name = reader.ReadElementString("Name");
            //this.ColumnName = reader.ReadElementString("ColumnName");
            //this.ReferenceTableName = reader.ReadElementString("ReferenceTableName");
            //this.ReferenceColumnName = reader.ReadElementString("ReferenceColumnName");
        }

        public override void WriteXml(XmlWriter writer)
        {
           // writer.WriteAttributeString("xsi:type", "ForeignKeyReferenceInfo");
            writer.WriteAttributeString("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance", this.GetType().Name);
            base.WriteXml(writer);
        }
    }

    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 6)]
    [UiNodeAttribute(ImageIndex = 8)]
    [XmlType(TypeName = "PrimaryKeyReferenceInfo")]
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
