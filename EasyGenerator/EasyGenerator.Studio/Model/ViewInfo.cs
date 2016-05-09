using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DbNodeAttribute(ImageIndex = 3)]
    public class ViewInfo : EntityInfo,ICloneable
    {
        public ViewInfo(ContextObject owner)
            : base(owner)
        {
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    [UiNodeAttribute(ImageIndex = 6)]
    public class UIViewInfo : UIEntityInfo
    {
        public UIViewInfo(ContextObject owner)
            : base(owner)
        {
        }
        public TableInfo TableInfo
        {
            get { return (TableInfo)base.EntityInfo; }
            set { base.EntityInfo = value; }
        }

        public override string ToString()
        {
            return TableInfo.ToString();
        }
    }
}
