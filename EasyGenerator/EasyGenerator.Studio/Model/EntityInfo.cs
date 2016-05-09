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

    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlInclude(typeof(UITableInfo))]
    [XmlInclude(typeof(UIViewInfo))]
    public abstract class UIEntityInfo : ContextObject
    {
        private EntityInfo entityInfo;
        private DBViewControlType dbViewControlType = DBViewControlType.DBGridView;
        private DBViewControl dbViewControl = null;

        public UIEntityInfo(ContextObject owner)
            : base(owner)
        {
            DBViewControl = new DBGridView(this);
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        public EntityInfo EntityInfo
        {
            get { return entityInfo; }
            set 
            { 
                entityInfo = value;

                if (!string.IsNullOrEmpty(entityInfo.Name) && dbViewControl != null)
                {
                    dbViewControl.Name = NomenclatureHelper.ConvertToPascalCase(entityInfo.Name);
                }

                if (!string.IsNullOrEmpty(entityInfo.Caption) && dbViewControl != null)
                {
                    dbViewControl.Caption = entityInfo.Caption;
                }
            }
        }

        [CategoryAttribute("显示")]
        [UiNodeInvisibleAttribute()]
        [XmlAttribute("DBViewControlType")]
        public DBViewControlType DBViewControlType
        {
            get { return dbViewControlType; }
            set
            {
                dbViewControlType = value;

                DBViewControl control = this.dbViewControl;

                this.dbViewControl = (DBViewControl)Activator.CreateInstance(Type.GetType(typeof(DBViewControl).Namespace + "." + dbViewControlType.ToString()));

                dbViewControl.Caption = control.Caption;
                dbViewControl.Name = control.Name;
                dbViewControl.Description = control.Description;
                dbViewControl.Owner = this;
            }
        }

        [CategoryAttribute("显示")]
        [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
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
            }
        }
    }
}
