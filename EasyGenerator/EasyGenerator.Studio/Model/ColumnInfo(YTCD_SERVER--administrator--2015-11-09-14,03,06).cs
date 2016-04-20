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

namespace EasyGenerator.Studio.Model
{
    
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 4)]
    [UiNodeAttribute(ImageIndex = 10)]
    public class ColumnInfo : ContextObject,ICloneable
    {
        private string name = "";
        private string caption="";
        private bool isPrimaryKey = false;
        private bool isForeignKey = false;
        private bool isIdentity = false;
        private bool isRequire = true;//是否为空
        private SqlType sqlType = SqlType.AnsiVarChar;
        private int length = 0;
        private int precision = 0;
        private int scale = 0;
        private string groupCaption = "";
        private bool visible = true;
        private string imprintField;


        private string imprintForeignField;


        private DBControlType dbControlType = DBControlType.DBEdit;
        private DBControl dbControl = new DBEdit();
        private ContextObjectDictionary<string, ReferenceInfo> references = null;


        public ColumnInfo()
        {
            dbControl.Owner = this;
            references= new ContextObjectDictionary<string, ReferenceInfo>(this);
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(""),ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public string Name
        {
            get { return name; }
            set {
                //if(string.IsNullOrEmpty(this.name) && string.IsNullOrEmpty(caption))
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "Name", caption);
                //}
                name = value;
                if (!string.IsNullOrEmpty(name) && dbControl!=null)
                {
                    dbControl.Name =NomenclatureHelper.ConvertToPascalCase(name);
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
                this.groupCaption = value;
                if (!string.IsNullOrEmpty(caption) && dbControl != null)
                {
                    dbControl.Caption = value;
                }
                NotifyPropertyChanged(this, "Caption");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(false), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public bool IsPrimaryKey
        {
            get { return isPrimaryKey; }
            set {
                //if (!isPrimaryKey && caption)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsPrimaryKey", caption);
                //}
                isPrimaryKey = value;
                NotifyPropertyChanged(this, "IsPrimaryKey");
                //if (isPrimaryKey)
                //{
                //    //Type type = typeof(DefaultValueAttribute);
                //    object []nodeAttributes = this.GetType().GetCustomAttributes(typeof(DbNodeAttribute), false);
                //    if (nodeAttributes != null && nodeAttributes.Length > 0)
                //    {
                //        DbNodeAttribute nodeAttribute = nodeAttributes[0] as DbNodeAttribute;
                //        nodeAttribute.ImageIndex = 5;

                //    }
                //}

            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(false), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public bool IsForeignKey
        {
            get { return isForeignKey; }
            set {
                //if (!isForeignKey && caption)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsForeignKey", caption);
                //}
                isForeignKey = value;
                NotifyPropertyChanged(this, "IsForeignKey");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(false), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public bool IsIdentity
        {
            get { return isIdentity; }
            set 
            {
                //if (!isIdentity && caption)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsIdentity", caption);
                //}
                isIdentity = value;
                NotifyPropertyChanged(this, "IsIdentity");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(false), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public bool IsRequire
        {
            get { return isRequire; }
            set { 
                isRequire = value;
                //if (!isRequire && caption)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsRequire", caption);
                //}
            }
        }

        [CategoryAttribute("数据库"), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public SqlType SqlType
        {
            get { return sqlType; }
            set {
                sqlType = value;
                NotifyPropertyChanged(this, "SqlType");
            }
        }



        [CategoryAttribute("数据库"), DefaultValueAttribute(0), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public int Length
        {
            get { return length; }
            set {
                //if (length==0 && caption>0)
                //{
                    PropertyHelper.SetPropertyDefaultValue(this, "Length", value);
                //}
                length = value;
                NotifyPropertyChanged(this, "Length");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(0), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public int Precision
        {
            get { return precision; }
            set {
                //if (precision == 0 && caption > 0)
                //{
                    PropertyHelper.SetPropertyDefaultValue(this, "Precision", value);
                //}
                precision = value;
                NotifyPropertyChanged(this, "Precision");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(0), ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public int Scale
        {
            get { return scale; }
            set {
                //if (scale == 0 && caption > 0)
                //{
                    PropertyHelper.SetPropertyDefaultValue(this, "Scale", value);
                //}
                scale = value;
                NotifyPropertyChanged(this, "Scale");
            }
        }

        [BrowsableAttribute(false)]
        public ContextObjectDictionary<string, ReferenceInfo> References
        {
            get { return references; }
           // set { references = caption; }
        }

        [CategoryAttribute("显示")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public DBControlType DBControlType
        {
            get { return dbControlType; }
            set
            {
                if (value == (Model.DBControlType.DBLookupListBox) || (value== Model.DBControlType.DBLookupTreeBox))
                {
                    int count = 0;
                    foreach (ReferenceInfo reference in references.Values)
                    {
                        if (reference is ForeignKeyReferenceInfo)
                        {
                            count++;
                            continue;
                        }
                    }
                    if(count<1)
                    {
                        throw new ArgumentException("当前数据库此字段未定义外键,无法使用此控件！");

                    }
                }



                dbControlType = value;
                DBControl control= this.dbControl;
                this.DBControl = (DBControl)Activator.CreateInstance(Type.GetType(typeof(DBControl).Namespace + "." + dbControlType.ToString()));

                DBControl.Caption = control.Caption;
                DBControl.Name = control.Name;
                DBControl.Description = control.Description;
                DBControl.Owner = this;

                NotifyPropertyChanged(this, "DBControlType");
            }
        }

        [CategoryAttribute("显示"), TypeConverterAttribute(typeof(ExpandableObjectConverter))]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public DBControl DBControl
        {
            get { return dbControl; }
            set 
            {
                dbControl = value;

                if (dbControl is DBLookupListBox)
                {
                    foreach (ReferenceInfo reference in references.Values)
                    {
                        if (reference is ForeignKeyReferenceInfo)
                        {
                            (dbControl as DBLookupListBox).LookupTable = reference.ReferenceTableName;
                            (dbControl as DBLookupListBox).LookupKeyField = reference.ReferenceColumnName;
                        }
                    }
                }
                if (dbControl is DBLookupTreeBox)
                {
                    foreach (ReferenceInfo reference in references.Values)
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
        [CategoryAttribute("显示"), DefaultValueAttribute(""),DescriptionAttribute("对此列信息进行分组！")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public string GroupCaption
        {
            get { return groupCaption; }
            set 
            { 
                groupCaption = value;
                NotifyPropertyChanged(this, "GroupCaption");
            }
        }

        [CategoryAttribute("显示"), DefaultValueAttribute(true), DescriptionAttribute("查询列表是否显示此列")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public bool Visible
        {
            get { return visible; }
            set 
            { 
                visible = value;
                NotifyPropertyChanged(this, "Visible");
            }
        }


        public string ImprintField
        {
            get { return imprintField; }
            set { imprintField = value; }
        }
        public string ImprintForeignField
        {
            get { return imprintForeignField; }
            set { imprintForeignField = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
            //MemoryStream stream = new MemoryStream();
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(stream, this);
            //stream.Position = 0;
            //return formatter.Deserialize(stream);
        }
    }
}
