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

namespace EasyGenerator.Studio.Model.DB
{
    
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 4)]
    [TypeConverter(typeof(PropertySorter))]
    [XmlInclude(typeof(PrimaryColumnInfo))]
    public class ColumnInfo : ContextObject,ICloneable
    {
        public ColumnInfo(ContextObject owner)
            :base(owner)
        {
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


   
}
