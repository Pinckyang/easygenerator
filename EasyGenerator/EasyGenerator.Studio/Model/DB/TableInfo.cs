using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model.DB
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [DbNodeAttribute(ImageIndex = 2)]
    
    public class TableInfo :EntityInfo,ICloneable
    {
        public TableInfo(ContextObject owner)
            : base(owner)
        {
        }
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
