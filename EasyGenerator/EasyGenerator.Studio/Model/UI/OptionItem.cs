using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    public struct OptionItem
    {
        private string value;

        [XmlAttribute("Value")]
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private string caption;

        public string Caption
        {
            get { return this.caption; }
            set { this.caption = value; }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Value) || string.IsNullOrEmpty(this.Caption))
            {
                return string.Empty;
            }
            return string.Format("[{0}:{1}]", this.Value, this.Caption);
        }
    }
}
