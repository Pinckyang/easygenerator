using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.Drawing.Design;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    public class DBComboListBoxField : UIColumnInfo, ICloneable
    {
        private string lookupTable;
        private List<string> lookupFields = new List<string>();
        private string lookupKeyField;


        public DBComboListBoxField(ContextObject owner)
            : base(owner)
        {
        }
        /// <summary>
        /// 外键表
        /// </summary>
        [XmlAttribute("LookupTable")]
        public string LookupTable
        {
            get { return lookupTable; }
            set
            {
                lookupTable = value;
                NotifyPropertyChanged(this, "LookupTable");
            }
        }

        /// <summary>
        /// 显示的列
        /// </summary>
        [Editor(typeof(CheckedListFromLookupTableEditor), typeof(UITypeEditor))]
        [XmlElement("LookupFields")]
        public List<string> LookupFields
        {
            get { return lookupFields; }
            set
            {
                lookupFields = value;
            }
        }

        /// <summary>
        /// 键值
        /// </summary>
        [Editor(typeof(ListColumnsFromLookupTableEditor), typeof(UITypeEditor))]
        [XmlAttribute("LookupKeyField")]
        public string LookupKeyField
        {
            get { return lookupKeyField; }
            set
            {
                lookupKeyField = value;
                NotifyPropertyChanged(this, "LookupKeyField");
            }
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
