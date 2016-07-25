using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    public class DBGridView : DBView, ICloneable
    {
        public DBGridView(ContextObject owner)
            : base(owner)
        {
        }
        public override string ToString()
        {
            return string.Empty;
        }
        public new object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
