using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyGenerator.Studio.PropertyTools;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    public class DBDatePickerField : GUIColumnInfo, ICloneable
    {
        private SearchMode searchMode = SearchMode.Single;
        private SearchModeControl searchModeControl = null;

        public DBDatePickerField(ContextObject owner)
            : base(owner)
        {
            SearchModeControl = new SearchDateSingleControl(this);
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


        [CategoryAttribute("显示")]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
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

        [CategoryAttribute("显示"), TypeConverterAttribute(typeof(ExpandableObjectConverter))]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
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

        public new object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
