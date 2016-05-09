using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing.Design;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    public class DBComboTreeListField : UIColumnInfo, ICloneable
    {
        private string lookupTable;
        private string lookupKeyField;
        private string lookupParentField;
        private string lookupRootValue = "-";
        private string lookupDisplayField;

        public DBComboTreeListField(ContextObject owner)
            : base(owner)
        {
        }

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
        [Editor(typeof(ListColumnsFromLookupTableEditor), typeof(UITypeEditor))]
        [XmlAttribute("LookupParentField")]
        public string LookupParentField
        {
            get { return lookupParentField; }
            set
            {
                lookupParentField = value;
                NotifyPropertyChanged(this, "LookupParentField");
            }
        }

        [DefaultValue("-")]
        [XmlAttribute("LookupRootValue")]
        public string LookupRootValue
        {
            get { return lookupRootValue; }
            set
            {
                lookupRootValue = value;
                NotifyPropertyChanged(this, "LookupRootValue");
            }
        }
        [Editor(typeof(ListColumnsFromLookupTableEditor), typeof(UITypeEditor))]
        [XmlAttribute("LookupDisplayField")]
        public string LookupDisplayField
        {
            get { return lookupDisplayField; }
            set
            {
                lookupDisplayField = value;
                NotifyPropertyChanged(this, "LookupDisplayField");
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
