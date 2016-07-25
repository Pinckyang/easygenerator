using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.UI
{
    /// <summary>
    /// Combox控件，自定义选项
    /// </summary>
    [Serializable()]
    public class DBComboBoxField : GUIColumnInfo, ICloneable
    {
        private List<OptionItem> fields = new List<OptionItem>();

        public DBComboBoxField(ContextObject owner)
            : base(owner)
        {
        }
        /// <summary>
        /// 在此预定义值
        /// </summary>
        [XmlElement("Fields")]
        public List<OptionItem> Fields
        {
            get { return fields; }
            set { fields = value; }
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
