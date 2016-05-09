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
    public class PrimaryColumnInfo:ColumnInfo,ICloneable
    {
        public PrimaryColumnInfo()
        {
            this.IsPrimaryKey = true;
        }
        public PrimaryColumnInfo(ColumnInfo column)
        {
            this.IsPrimaryKey = true;
            this.Caption=column.Caption;
            this.DBControl=column.DBControl;
            this.DBControlType=column.DBControlType;
            this.GroupCaption=column.GroupCaption;
            this.IsForeignKey=column.IsForeignKey;
            this.IsIdentity=column.IsIdentity;
            this.IsRequire=column.IsRequire;
            this.Length=column.Length;
            this.Name=column.Name;
            this.Precision=column.Precision;
            this.Owner = column.Owner;

            foreach (ReferenceInfo reference in column.References)
            {
                this.References.Add((ReferenceInfo)reference.Clone());
            }
            this.Scale=column.Scale;
            this.SqlType=column.SqlType;
           
        }

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
