using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    public class DBDateTimePickerField : UIColumnInfo, ICloneable
    {
        private SearchMode searchMode = SearchMode.Single;
        private SearchModeControl searchModeControl = null;

        public DBDateTimePickerField(ContextObject owner)
            : base(owner)
        {
            searchModeControl = new SearchDateSingleControl(this);
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

        /// <summary>
        /// 当选择查询模式时
        /// </summary>
        [XmlAttribute("SearchMode")]
        public SearchMode SearchMode
        {
            get { return searchMode; }
            set
            {
                searchMode = value;
                this.SearchModeControl = (SearchModeControl)Activator.CreateInstance(Type.GetType(typeof(SearchModeControl).Namespace + ".SearchDate" + searchMode.ToString() + "Control"));
                this.DefaultSearchValue = string.Empty;
            }
        }

        [XmlElement(Type = typeof(SearchDateRangeControl), ElementName = "SearchDateRangeControl")]
        [XmlElement(Type = typeof(SearchDateSingleControl), ElementName = "SearchDateSingleControl")]
        public SearchModeControl SearchModeControl
        {
            get { return searchModeControl; }
            set
            {
                searchModeControl = value;

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
