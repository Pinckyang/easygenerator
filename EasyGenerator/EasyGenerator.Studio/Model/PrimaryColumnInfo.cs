using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 5)]
    [UiNodeAttribute(ImageIndex = 7)]
    public class PrimaryColumnInfo : ColumnInfo, ICloneable
    {
        public PrimaryColumnInfo(ContextObject owner)
            :base(owner)
        {
            this.IsPrimaryKey = true;
        }
        //public PrimaryColumnInfo(ColumnInfo column)
        //{
        //    this.IsPrimaryKey = true;
        //    this.Caption = column.Caption;
        //    //TODO:this.DBControl = column.DBControl;
        //    //TODO:this.DBControlType = column.DBControlType;
        //    //TODO:this.GroupCaption = column.GroupCaption;
        //    this.IsForeignKey = column.IsForeignKey;
        //    this.IsIdentity = column.IsIdentity;
        //    this.IsRequire = column.IsRequire;
        //    this.Length = column.Length;
        //    this.Name = column.Name;
        //    this.Precision = column.Precision;
        //    this.Owner = column.Owner;

        //    foreach (ReferencedInfo referenced in column.Referenced)
        //    {
        //        this.Referenced.Add((ReferencedInfo)referenced.Clone());
        //    }
        //    this.Scale = column.Scale;
        //    this.SqlType = column.SqlType;

        //}

        public override string ToString()
        {
            return this.Name;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
