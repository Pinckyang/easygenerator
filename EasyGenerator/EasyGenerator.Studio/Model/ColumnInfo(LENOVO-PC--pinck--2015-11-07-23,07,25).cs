using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.Utils;
using System.Reflection;

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
        private DBControlType dbControlType = DBControlType.DBEdit;
        private DBControl dbControl = new DBEdit();
        private ContextObjectDictionary<string, ReferenceInfo> references = null;
       // private object owner;

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
                //if(string.IsNullOrEmpty(this.name) && string.IsNullOrEmpty(value))
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "Name", value);
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
                //if (!isPrimaryKey && value)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsPrimaryKey", value);
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
                //if (!isForeignKey && value)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsForeignKey", value);
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
                //if (!isIdentity && value)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsIdentity", value);
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
                //if (!isRequire && value)
                //{
                //    PropertyHelper.SetPropertyDefaultValue(this, "IsRequire", value);
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
                //if (length==0 && value>0)
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
                //if (precision == 0 && value > 0)
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
                //if (scale == 0 && value > 0)
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
           // set { references = value; }
        }

        [CategoryAttribute("显示")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public DBControlType DBControlType
        {
            get { return dbControlType; }
            set
            {
                dbControlType = value;
                DBControl control= this.dbControl;
                this.dbControl = (DBControl)Activator.CreateInstance(Type.GetType(typeof(DBControl).Namespace+"." + dbControlType.ToString()));

                dbControl.Caption = control.Caption;
                dbControl.Name = control.Name;
                dbControl.Description = control.Description;
                dbControl.Owner = this;

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

                if (dbControlType == Model.DBControlType.DBLookupListBox && dbControl is DBLookupListBox)
                {
                    if (References.Count > 0)
                    {
 
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


        //[BrowsableAttribute(false)]
        //[DbNodeInvisibleAttribute()]
        //[UiNodeInvisibleAttribute()]
        //public object Owner
        //{
        //    get { return owner; }
        //    set
        //    {
        //        owner = value;
        //    }
        //}

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
