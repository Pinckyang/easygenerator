using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.Model.Db;

namespace EasyGenerator.Studio.Model.Ui
{

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
            Fields =new ContextObjectList<UIColumnInfo>(this);
            DetailViews = new ContextObjectList<UIEntityInfo>(this);
        }

        public string Caption
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        public EntityInfo EntityInfo
        {
            get { return entityInfo; }
            set
            {
                this.entityInfo = value;
                this.entityInfo.Owner = this;
                

                if (!string.IsNullOrEmpty(entityInfo.Name) && dbViewControl != null)
                {
                    dbViewControl.Name = NomenclatureHelper.ConvertToPascalCase(entityInfo.Name);
                }

                if (!string.IsNullOrEmpty(entityInfo.Caption) && dbViewControl != null)
                {
                    dbViewControl.Caption = entityInfo.Caption;
                    this.Caption = entityInfo.Caption;
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

                this.dbViewControl = (DBViewControl)Activator.CreateInstance(Type.GetType(typeof(DBViewControl).Namespace + "." + dbViewControlType.ToString()),this);

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

        public List<UIColumnInfo> Fields
        {
            get;
            set;
        }

        public List<UIEntityInfo> DetailViews
        {
            get;
            set;
        }
    }
}
