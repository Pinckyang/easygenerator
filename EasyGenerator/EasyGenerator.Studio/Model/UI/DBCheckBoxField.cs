using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    public class DBCheckBoxField : UIColumnInfo, ICloneable
    {
        public DBCheckBoxField(ContextObject owner)
            : base(owner)
        {
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
