using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;
using System.Drawing.Design;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [TypeConverter(typeof(PropertySorter))]
    public class DBControl:ContextObject,ICloneable
    {
        private int colSpan=1;
        private int rowSpan=1;
        private TextAlign labelAlign = TextAlign.RightToLeft;
        private string name = "";
        private string caption = "";
        private string description = "";
        private bool allowAdd = false;
        private bool allowEdit = false;
        private bool allowSearch = false;
        private string defaultAddValue = "";
        private string defaultEditValue = "";
        private string defaultSearchValue = "";


        public DBControl(ContextObject owner)
            :base(owner)
        {
        }


        [CategoryAttribute("显示"),DefaultValue(1),Description("控件列跨度，默认为1.")]
        [XmlAttribute("ColSpan")]
        public virtual int ColSpan
        {
            get { return colSpan; }
            set 
            { 
                colSpan = value;
                NotifyPropertyChanged(this, "ColSpan");
            }
        }

        [CategoryAttribute("显示"), DefaultValue(1), Description("控件行跨度，默认为1.")]
        [XmlAttribute("RowSpan")]
        public virtual int RowSpan
        {
            get { return rowSpan; }
            set 
            { 
                rowSpan = value;
                NotifyPropertyChanged(this, "RowSpan");
            }
        }

        [CategoryAttribute("显示"), DefaultValue(TextAlign.RightToLeft)]
        [XmlAttribute("LabelAlign")]
        public TextAlign LabelAlign
        {
            get { return labelAlign; }
            set 
            {
                labelAlign = value;
                NotifyPropertyChanged(this, "LabelAlign");
            }
        }
        [CategoryAttribute("显示")]
        [XmlAttribute("Name")]
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                NotifyPropertyChanged(this, "Name");
            }
        }

        [CategoryAttribute("显示"), DefaultValueAttribute("")]
        [XmlAttribute("Caption")]
        public string Caption
        {
            get { return caption; }
            set 
            {
                caption = value;
                NotifyPropertyChanged(this, "Caption");
            }
        }

        [CategoryAttribute("显示"), DefaultValueAttribute("")]
        [XmlAttribute("Description")]
        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                NotifyPropertyChanged(this, "Description");
            }
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute("AllowAdd")]
        public bool AllowAdd
        {
            get { return allowAdd; }
            set 
            { 
                allowAdd = value;

                NotifyPropertyChanged(this, "AllowAdd");
            }
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute("AllowEdit")]
        public bool AllowEdit
        {
            get { return allowEdit; }
            set 
            { 
                allowEdit = value;

                NotifyPropertyChanged(this, "AllowEdit");
            }
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute("AllowSearch")]
        public bool AllowSearch
        {
            get { return allowSearch; }
            set 
            { 
                allowSearch = value;
                NotifyPropertyChanged(this, "AllowSearch");
            }
        }

        [CategoryAttribute("显示"), TypeConverter(typeof(StringValueDefaultConverter))]
        [XmlAttribute("DefaultAddValue")]
        public virtual string DefaultAddValue
        {
            get { return defaultAddValue; }
            set 
            { 
                defaultAddValue = value;

                NotifyPropertyChanged(this, "DefaultAddValue");
            }
        }

        [CategoryAttribute("显示"), TypeConverter(typeof(StringValueDefaultConverter))]
        [XmlAttribute("DefaultEditValue")]
        public virtual string DefaultEditValue
        {
            get { return defaultEditValue; }
            set 
            { 
                defaultEditValue = value;
                NotifyPropertyChanged(this, "DefaultEditValue");
            }
        }

        [CategoryAttribute("显示"), TypeConverter(typeof(StringValueDefaultConverter))]
        [XmlAttribute("DefaultSearchValue")]
        public virtual string DefaultSearchValue
        {
            get { return defaultSearchValue; }
            set 
            { 
                defaultSearchValue = value;
                NotifyPropertyChanged(this, "DefaultSearchValue");
            }
        }
        public override string ToString()
        {
            return string.Empty;
        }

        public object Clone()
        {

            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBText : DBControl, ICloneable
    {
        public DBText(ContextObject owner)
            : base(owner)
        {
        }

        object ICloneable.Clone()
        {

            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBEdit: DBControl,ICloneable
    {
        public DBEdit(ContextObject owner)
            : base(owner)
        {
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

    [Serializable()]
    public class DBButtonEdit : DBControl, ICloneable
    {
        public DBButtonEdit(ContextObject owner)
            : base(owner)
        {
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

    [Serializable()]
    public class DBPassword: DBControl,ICloneable
    {
        public DBPassword(ContextObject owner)
            : base(owner)
        {
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

    /// <summary>
    /// Combox控件，自定义选项
    /// </summary>
    [Serializable()]
    public class DBComboBox: DBControl,ICloneable
    {
        private List<OptionItem> fields = new List<OptionItem>();

        public DBComboBox(ContextObject owner)
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBLookupListBox : DBControl, ICloneable
    {
        private string lookupTable;
        private List<string> lookupFields = new List<string>();
        private string lookupKeyField;


        public DBLookupListBox(ContextObject owner)
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

    [Serializable()]
    public class DBLookupTreeBox: DBControl,ICloneable
    {
        private string lookupTable;
        private string lookupKeyField;
        private string lookupParentField;
        private string lookupRootValue="-";
        private string lookupDisplayField;

        public DBLookupTreeBox(ContextObject owner)
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

    [Serializable()]
    public class DBRichEdit: DBControl,ICloneable
    {
        public DBRichEdit(ContextObject owner)
            : base(owner)
        {
            ColSpan = 2;
            RowSpan=2;
        }
        [DefaultValue(2)]
        [XmlAttribute("ColSpan")]
        public override int ColSpan
        {
            get
            {
                return base.ColSpan;
            }
            set
            {
                base.ColSpan = value;

            }
        }
        [DefaultValue(2)]
        [XmlAttribute("RowSpan")]
        public override int RowSpan
        {
            get
            {
                return base.RowSpan;
            }
            set
            {
                base.RowSpan = value;
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

    [Serializable()]
    public class DBDatePicker: DBControl,ICloneable
    {
        private SearchMode searchMode = SearchMode.Single;
        private SearchModeControl searchModeControl = null;

        public DBDatePicker(ContextObject owner)
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

        [CategoryAttribute("显示"),Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
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
                this.SearchModeControl = (SearchModeControl)Activator.CreateInstance(Type.GetType(typeof(SearchModeControl).Namespace + ".SearchDate" + searchMode.ToString()+"Control"));
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBDateTimePicker: DBControl,ICloneable
    {
        private SearchMode searchMode = SearchMode.Single;
        private SearchModeControl searchModeControl = null;

        public DBDateTimePicker(ContextObject owner)
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

    [Serializable()]
    public class DBTimePicker : DBControl, ICloneable
    {
        private SearchMode searchMode = SearchMode.Single;
        private string defaultSearchFromTimeValue = "";
        private string defaultSearchToTimeValue = "";

        public DBTimePicker(ContextObject owner)
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBBinaryImage: DBControl,ICloneable
    {
        public DBBinaryImage(ContextObject owner)
            : base(owner)
        {
            RowSpan = 2;
        }
        [DefaultValue(1)]
        [XmlAttribute("ColSpan")]
        public override int ColSpan
        {
            get
            {
                return base.ColSpan;
            }
            set
            {
                base.ColSpan = value;
            }
        }

        [DefaultValue(2)]
        [XmlAttribute("RowSpan")]
        public override int RowSpan
        {
            get
            {
                return base.RowSpan;
            }
            set
            {
                base.RowSpan = value;
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

    [Serializable()]
    public class DBPathImage : DBControl, ICloneable
    {
        public DBPathImage(ContextObject owner)
            : base(owner)
        {
            this.ColSpan = 2;
        }

        [DefaultValue(2)]
        [XmlAttribute("ColSpan")]
        public override int ColSpan
        {
            get
            {
                return base.ColSpan;
            }
            set
            {
                base.ColSpan = value;
            }
        }

        [DefaultValue(1)]
        [XmlAttribute("RowSpan")]
        public override int RowSpan
        {
            get
            {
                return base.RowSpan;
            }
            set
            {
                base.RowSpan = value;
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


    [Serializable()]
    public class DBCheckBox : DBControl,ICloneable
    {
        public DBCheckBox(ContextObject owner)
            : base(owner)
        {
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

    [Serializable()]
    public class DBRadioGroup : DBControl, ICloneable
    {
        private List<OptionItem> radios = new List<OptionItem>();

        public DBRadioGroup(ContextObject owner)
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
