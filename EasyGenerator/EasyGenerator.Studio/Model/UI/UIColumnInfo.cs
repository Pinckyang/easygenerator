using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyGenerator.Studio.PropertyTools;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNodeAttribute(ImageIndex = 10)]
    [TypeConverter(typeof(PropertySorter))]
    [XmlInclude(typeof(PrimaryColumnInfo))]
    public class UIColumnInfo : ContextObject
    {
        //private string groupCaption = "";
        //private bool visible = true;
        //private DBControlType dbControlType = DBControlType.DBEdit;
        //private DBControl dbControl = null;

        public UIColumnInfo(ContextObject owner)
            : base(owner)
        {
            //DBControl = new DBEdit(this);
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [XmlElement]
        public ColumnInfo ColumnInfo
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValue(1), Description("控件列跨度，默认为1.")]
        [XmlAttribute]
        public virtual int ColSpan
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValue(1), Description("控件行跨度，默认为1.")]
        [XmlAttribute]
        public virtual int RowSpan
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValue(TextAlign.RightToLeft)]
        [XmlAttribute]
        public TextAlign LabelAlign
        {
            get;
            set;
        }
        [CategoryAttribute("显示")]
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValueAttribute("")]
        [XmlAttribute]
        public string Caption
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValueAttribute("")]
        [XmlAttribute]
        public string Description
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute]
        public bool AllowAdd
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute]
        public bool AllowEdit
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute]
        public bool AllowSearch
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), TypeConverter(typeof(StringValueDefaultConverter))]
        [XmlAttribute]
        public virtual string DefaultAddValue
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), TypeConverter(typeof(StringValueDefaultConverter))]
        [XmlAttribute]
        public virtual string DefaultEditValue
        {
            get;
            set;
        }

        [CategoryAttribute("显示"), TypeConverter(typeof(StringValueDefaultConverter))]
        [XmlAttribute]
        public virtual string DefaultSearchValue
        {
            get;
            set;
        }

        /*
        [CategoryAttribute("显示")]
        [UiNodeInvisibleAttribute()]
        [XmlAttribute("DBControlType")]
        public DBControlType DBControlType
        {
            get { return dbControlType; }
            set
            {
                dbControlType = value;
                DBControl control = this.dbControl;
                this.DBControl = (DBControl)Activator.CreateInstance(Type.GetType(typeof(DBControl).Namespace + "." + dbControlType.ToString()));

                DBControl.Caption = control.Caption;
                DBControl.Name = control.Name;
                DBControl.Description = control.Description;
                DBControl.Owner = this;
            }
        }

        [CategoryAttribute("显示")]
        [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlElement(Type = typeof(DBBinaryImage), ElementName = "DBBinaryImage")]
        [XmlElement(Type = typeof(DBButtonEdit), ElementName = "DBButtonEdit")]
        [XmlElement(Type = typeof(DBCheckBox), ElementName = "DBCheckBox")]
        [XmlElement(Type = typeof(DBComboBox), ElementName = "DBComboBox")]
        [XmlElement(Type = typeof(DBDatePicker), ElementName = "DBDatePicker")]
        [XmlElement(Type = typeof(DBDateTimePicker), ElementName = "DBDateTimePicker")]
        [XmlElement(Type = typeof(DBEdit), ElementName = "DBEdit")]
        [XmlElement(Type = typeof(DBLookupListBox), ElementName = "DBLookupListBox")]
        [XmlElement(Type = typeof(DBLookupTreeBox), ElementName = "DBLookupTreeBox")]
        [XmlElement(Type = typeof(DBPassword), ElementName = "DBPassword")]
        [XmlElement(Type = typeof(DBPathImage), ElementName = "DBPathImage")]
        [XmlElement(Type = typeof(DBRadioGroup), ElementName = "DBRadioGroup")]
        [XmlElement(Type = typeof(DBRichEdit), ElementName = "DBRichEdit")]
        [XmlElement(Type = typeof(DBText), ElementName = "DBText")]
        [XmlElement(Type = typeof(DBTimePicker), ElementName = "DBTimePicker")]
        public DBControl DBControl
        {
            get { return dbControl; }
            set
            {
                dbControl = value;

                if (dbControl is DBLookupListBox)
                {
                    (dbControl as DBLookupListBox).LookupTable = ColumnInfo.Referencing.ReferencingTableName;
                    (dbControl as DBLookupListBox).LookupKeyField = ColumnInfo.Referencing.ReferencingKey;
                }
                if (dbControl is DBLookupTreeBox)
                {
                    //TODO:
                    //foreach (ReferenceInfo reference in References)
                    //{
                    //    if (reference is ForeignKeyReferenceInfo)
                    //    {
                    //        (dbControl as DBLookupTreeBox).LookupTable = reference.ReferenceTableName;
                    //        (dbControl as DBLookupTreeBox).LookupKeyField = reference.ReferenceColumnName;
                    //        (dbControl as DBLookupTreeBox).LookupDisplayField = reference.ReferenceColumnName;
                    //        (dbControl as DBLookupTreeBox).LookupRootValue = "-";
                    //    }
                    //}
                }

                NotifyPropertyChanged(this, "DBControl");
            }
        }

        //显示分组标头，默认分组标头等于caption
        [CategoryAttribute("显示")]
        [DefaultValueAttribute("")]
        [DescriptionAttribute("对此列信息进行分组！")]
        [UiNodeInvisibleAttribute()]
        [XmlAttribute("GroupCaption")]
        public string GroupCaption
        {
            get
            {
                if (string.IsNullOrEmpty(this.groupCaption))
                {
                    groupCaption = ColumnInfo.Caption;
                }
                return groupCaption;
            }
            set
            {
                GroupCaption = value;
            }
        }

        [CategoryAttribute("显示")]
        [DefaultValueAttribute(true)]
        [DescriptionAttribute("查询列表是否显示此列")]
        [UiNodeInvisibleAttribute()]
        [XmlAttribute("Visible")]
        public bool Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                NotifyPropertyChanged(this, "Visible");
            }
        }*/

        public override string ToString()
        {
            return ColumnInfo.Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
