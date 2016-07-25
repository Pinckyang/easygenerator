using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    public class DBTextField : GUIColumnInfo, ICloneable
    {
        public DBTextField(ContextObject owner)
            : base(owner)
        {
        }

        object ICloneable.Clone()
        {

            return this.MemberwiseClone();
        }
    }
}
