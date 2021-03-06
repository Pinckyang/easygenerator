﻿using System;
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

namespace EasyGenerator.Studio.Model.DB
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    //[XmlInclude(typeof(ForeignKeyConstraint))]
    //[XmlInclude(typeof(ReferencingInfo))]
    public class ForeignKeyConstraint : ContextObject, ICloneable
    {

        public ForeignKeyConstraint(ContextObject owner)
            :base(owner)
        {
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("Name")]
        public string Name
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("RelatedTableName")]
        public string RelatedTableName
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("RelatedKey")]
        public string RelatedKey
        {
            get;
            set;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

    /*/// <summary>
    /// 外键关联referencing table
    /// </summary>
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 7)]
    //[UiNodeAttribute(ImageIndex = 9)]
    [XmlType(TypeName = "ReferencingInfo")]
    public class ReferencingInfo : Constraint, ICloneable
    {
        public ReferencingInfo(ContextObject owner)
            : base(owner)
        {
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlIgnore]
        public virtual EntityInfo ReferencingTable
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("ReferencingTableName")]
        public string ReferencingTableName
        {
            get{ return ReferencingTable.Name; }
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute("ReferencingKey")]
        public string ReferencingKey
        {
            get 
            { 
                foreach(ColumnInfo column in ReferencingTable.Columns)
                {
                    if (column.IsPrimaryKey && column.Referenced.Find(e => e.Name == this.Name) != null)
                    {
                        return column.Name;
                    }
                }
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1}->[{2}:{3}])", this.Name, "Master", this.ReferencingTableName,this.ReferencingKey);
        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }*/
    /*
    /// <summary>
    ///主键被关联 referenced table
    /// </summary>
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 6)]
   // [UiNodeAttribute(ImageIndex = 8)]
    [XmlType(TypeName = "ForeignKeyConstraint")]
    public class ForeignKeyConstraint : Constraint, ICloneable
    {
        public ForeignKeyConstraint(ContextObject owner)
            : base(owner)
        {
        }

        /*[CategoryAttribute("数据库")]
        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlIgnore]
        public virtual EntityInfo ReferencedTable
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute]
        public string ReferencedTableName
        {
            get { return ReferencedTable.Name; }
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute]
        public string ReferencedKey
        {
            get
            {
                foreach (ColumnInfo column in ReferencedTable.Columns)
                {
                    if (column.IsForeignKey && column.Referenced.Find(e => e.Name == this.Name) != null)
                    {
                        return column.Name;
                    }
                }
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1}->[{2}:{3}])", this.Name, "Detail", this.ReferencedTableName, this.ReferencedKey);
        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }*/

        /// <summary>
    /// 外键关联referencing table
    /// </summary>
    [Serializable()]
    [UiNodeAttribute(ImageIndex = 9)]
    [XmlType(TypeName = "UIReferencingInfo")]
    public class UIReferencingInfo:ContextObject
    {
        public UIReferencingInfo(ContextObject owner)
            : base(owner)
        {
            //ReferencingInfo = new ReferencingInfo(this);
        }
      

        //public ReferencingInfo ReferencingInfo
        //{
        //    get;
        //    set;
        //}
    }

    /// <summary>
    ///主键被关联 referenced table
    /// </summary>
    [Serializable()]
    [UiNodeAttribute(ImageIndex = 8)]
    [XmlType(TypeName = "UIReferencedInfo")]
    public class UIReferencedInfo : ContextObject,ICloneable
    {
        public UIReferencedInfo(ContextObject owner)
            : base(owner)
        {
        }
        [CategoryAttribute("数据库")]
        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlIgnore]
        public virtual EntityInfo ReferencedTable
        {
            get;
            set;
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute]
        public string ReferencedTableName
        {
            get { return ReferencedTable.Name; }
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [ReadOnly(true)]
        [DbNodeInvisibleAttribute()]
        [XmlAttribute]
        public string ReferencedKey
        {
            get
            {
                //foreach (ColumnInfo column in ReferencedTable.Columns)
                //{
                //    if (column.IsForeignKey && column.Referenced.Find(e => e.Name == this.Name) != null)
                //    {
                //        return column.Name;
                //    }
                //}
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return string.Empty;// string.Format("{0}({1}->[{2}:{3}])", this.Name, "Detail", this.ReferencedTableName, this.ReferencedKey);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
