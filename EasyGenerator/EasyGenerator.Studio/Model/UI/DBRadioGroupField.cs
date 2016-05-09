using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    public class DBRadioGroupField : UIColumnInfo, ICloneable
    {
        private List<OptionItem> radios = new List<OptionItem>();

        public DBRadioGroupField(ContextObject owner)
            : base(owner)
        {
        }

        [XmlElement("Radios")]
        public List<OptionItem> Radios
        {
            get { return radios; }
            set { radios = value; }
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
