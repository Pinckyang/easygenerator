using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    public class DBTimePickerField : GUIColumnInfo, ICloneable
    {
        private SearchMode searchMode = SearchMode.Single;
        private string defaultSearchFromTimeValue = "";
        private string defaultSearchToTimeValue = "";

        public DBTimePickerField(ContextObject owner)
            : base(owner)
        {
        }

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("DefaultAddValue")]
        public override string DefaultAddValue
        {
            get { return base.DefaultAddValue; }
            set { base.DefaultAddValue = value; }
        }

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("DefaultEditValue")]
        public override string DefaultEditValue
        {
            get
            {
                return base.DefaultEditValue;
            }
            set
            {
                base.DefaultEditValue = value;
            }
        }

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("DefaultSearchValue")]
        public override string DefaultSearchValue
        {
            get
            {
                return base.DefaultSearchValue;
            }
            set
            {
                base.DefaultSearchValue = value;
            }
        }
        [Browsable(false), TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("DefaultSearchFromTimeValue")]
        public string DefaultSearchFromTimeValue
        {
            get
            {
                return defaultSearchFromTimeValue;
            }
            set
            {
                defaultSearchFromTimeValue = value;
            }
        }

        [Browsable(false), TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("DefaultSearchToTimeValue")]
        public string DefaultSearchToTimeValue
        {
            get { return defaultSearchToTimeValue; }
            set { defaultSearchToTimeValue = value; }
        }

        [XmlAttribute("SearchMode")]
        public SearchMode SearchMode
        {
            get { return searchMode; }
            set
            {
                searchMode = value;

                this.DefaultSearchValue = string.Empty;
            }
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
