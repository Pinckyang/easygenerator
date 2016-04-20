using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 2)]
    [UiNodeAttribute(ImageIndex = 5)]
    public class TableInfo :EntityInfo,ICloneable
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
