using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.Utils;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 4)]
    [TypeConverter(typeof(PropertySorter))]
    [XmlInclude(typeof(PrimaryColumnInfo))]
    public class ColumnInfo : ContextObject,ICloneable
    {
        public ColumnInfo()
        {
            Referencing= new ContextObjectList<ReferencingInfo>(this);
            Referenced = new ContextObjectList<ReferencedInfo>(this);
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Name")]
        public string Name
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DefaultValueAttribute("")]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Caption")]
        public string Caption
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("IsPrimaryKey")]
        public bool IsPrimaryKey
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("IsForeignKey")]
        public bool IsForeignKey
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("IsIdentity")]
        public bool IsIdentity
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("IsRequire")]
        public bool IsRequire
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("SqlType")]
        public SqlType SqlType
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Length")]
        public int Length
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Precision")]
        public int Precision
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Scale")]
        public int Scale
        {
            get;
            set;
        }

        /// <summary>
        /// 外键关不错
        /// </summary>
        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [BrowsableAttribute(false)]
        [XmlElement("Referencing")]
        public ReferencingInfo Referencing
        {
            get;
            set;
        }

        /// <summary>
        /// 明细表关联
        /// </summary>
        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        [BrowsableAttribute(false)]
        [XmlElement("Referenced")]
        public List<ReferencedInfo> Referenced
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNodeAttribute(ImageIndex = 10)]
    [TypeConverter(typeof(PropertySorter))]
    [XmlInclude(typeof(PrimaryColumnInfo))]
    public class UIColumnInfo : ColumnInfo
    {
        private string groupCaption = "";
        private bool visible = true;
        private DBControlType dbControlType = DBControlType.DBEdit;
        private DBControl dbControl = new DBEdit();
        private ColumnInfo columnInfo;


        public UIColumnInfo()
        {
            dbControl.Owner = this;
        }

        [CategoryAttribute("数据库")]
        [ReadOnly(true)]
        public ColumnInfo ColumnInfo
        {
            get { return columnInfo; }
            set { columnInfo = value; }
        }


        [CategoryAttribute("显示")]
        [UiNodeInvisibleAttribute()]
        [XmlAttribute("DBControlType")]
        public DBControlType DBControlType
        {
            get { return dbControlType; }
            set
            {
                //if (value == (Model.DBControlType.DBLookupListBox) || (value== Model.DBControlType.DBLookupTreeBox))
                //{
                //    //int count = 0;
                //    //foreach (ReferencingInfo reference in columnInfo.Referencing)
                //    //{
                //    //    if (reference is ForeignKeyReferenceInfo)
                //    //    {
                //    //        count++;
                //    //        continue;
                //    //    }
                //    //}
                //    //if(count<1)
                //    //{
                //    //    throw new ArgumentException("当前数据库此字段未定义外键,无法使用此控件！");

                //    //}
                //}



                dbControlType = value;
                DBControl control= this.dbControl;
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
                    (dbControl as DBLookupListBox).LookupTable = columnInfo.Referencing.ReferencingTableName;
                    (dbControl as DBLookupListBox).LookupKeyField = columnInfo.Referencing.ReferencingKey;
                }
                if (dbControl is DBLookupTreeBox)
                {
                    foreach (ReferenceInfo reference in References)
                    {
                        if (reference is ForeignKeyReferenceInfo)
                        {
                            (dbControl as DBLookupTreeBox).LookupTable = reference.ReferenceTableName;
                            (dbControl as DBLookupTreeBox).LookupKeyField = reference.ReferenceColumnName;
                            (dbControl as DBLookupTreeBox).LookupDisplayField = reference.ReferenceColumnName;
                            (dbControl as DBLookupTreeBox).LookupRootValue = "-";
                        }
                    }
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
                    groupCaption = this.Caption;
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
        }

        public override string ToString()
        {
            return this.Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
