using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    public class DBTextField : UIColumnInfo, ICloneable
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
