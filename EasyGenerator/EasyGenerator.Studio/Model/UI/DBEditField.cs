using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    public class DBEditField : UIColumnInfo, ICloneable
    {
        public DBEditField(ContextObject owner)
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
