using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlInclude(typeof(TableInfo))]
    [XmlInclude(typeof(ViewInfo))]
    public abstract class EntityInfo : ContextObject
    {
        private string name;
        private string caption;
        private string schema="dbo";
        private DBViewControlType dbViewControlType = DBViewControlType.DBGridView;
        private DBViewControl dbViewControl = new DBGridView();

        public EntityInfo()
        {
            dbViewControl.Owner = this;
            Columns= new ContextObjectDictionary<string, ColumnInfo>(this);
        }


        [CategoryAttribute("数据库"), DefaultValueAttribute(""), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (!string.IsNullOrEmpty(name) && dbViewControl != null)
                {
                    dbViewControl.Name = NomenclatureHelper.ConvertToPascalCase(name);
                }

                NotifyPropertyChanged(this, "Name");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute("")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public string Caption
        {
            get { return caption; }
            set 
            {
                caption = value;
                if (!string.IsNullOrEmpty(caption) && dbViewControl != null)
                {
                    dbViewControl.Caption = value;
                }

                NotifyPropertyChanged(this, "Caption");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(""), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public string Schema
        {
            get { return schema; }
            set 
            { 
                schema = value;
                NotifyPropertyChanged(this, "Schema");
            }
        }

        [CategoryAttribute("显示")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public DBViewControlType DBViewControlType
        {
            get { return dbViewControlType; }
            set { 
                dbViewControlType = value;

                DBViewControl control = this.dbViewControl;

                this.dbViewControl = (DBViewControl)Activator.CreateInstance(Type.GetType(typeof(DBViewControl).Namespace + "." + dbViewControlType.ToString()));

                dbViewControl.Caption = control.Caption;
                dbViewControl.Name = control.Name;
                dbViewControl.Description = control.Description;
                dbViewControl.Owner = this;

                NotifyPropertyChanged(this, "DBViewControlType");
            }
        }

        [CategoryAttribute("显示"), TypeConverterAttribute(typeof(ExpandableObjectConverter))]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement(Type = typeof(DBGridView), ElementName = "DBGridView")]
        [XmlElement(Type = typeof(DBTreeView), ElementName = "DBTreeView")]
        public DBViewControl DBViewControl
        {
            get { return dbViewControl; }
            set
            {
                dbViewControl = value;
                NotifyPropertyChanged(this, "DBViewControl");
            }
        }

        [BrowsableAttribute(false)]
        [ReadOnly(true)]
       // [XmlElement(Type = typeof(ContextObjectDictionary<string,PrimaryColumnInfo>), ElementName = "PrimaryColumnInfo")]
        public ContextObjectDictionary<string, ColumnInfo> Columns
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
