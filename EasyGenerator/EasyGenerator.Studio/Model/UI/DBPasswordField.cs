using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    public class DBPasswordField : GUIColumnInfo, ICloneable
    {
        public DBPasswordField(ContextObject owner)
            : base(owner)
        {
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public new object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
