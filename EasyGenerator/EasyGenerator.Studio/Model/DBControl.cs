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



        [CategoryAttribute("显示"),DefaultValue(1),Description("控件列跨度，默认为1.")]
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

        object ICloneable.Clone()
        {

            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBEdit: DBControl,ICloneable
    {

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

        /// <summary>
        /// 在此预定义值
        /// </summary>
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

        /// <summary>
        /// 外键表
        /// </summary>
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
        public DBRichEdit()
        {
            ColSpan = 2;
            RowSpan=2;
        }
        [DefaultValue(2)]
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
        private SearchModeControl searchModeControl = new SearchDateSingleControl();


        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
        public override string DefaultAddValue
        {
            get { return base.DefaultAddValue; }
            set { base.DefaultAddValue = value; }
        }

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
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
        private SearchModeControl searchModeControl = new SearchDateSingleControl();

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
        public override string DefaultAddValue
        {
            get { return base.DefaultAddValue; }
            set { base.DefaultAddValue = value; }
        }

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
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

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
        public override string DefaultAddValue
        {
            get { return base.DefaultAddValue; }
            set { base.DefaultAddValue = value; }
        }

        [CategoryAttribute("显示"), Browsable(true), TypeConverter(typeof(DateTimeDefaultConverter))]
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
        public string DefaultSearchToTimeValue
        {
            get { return defaultSearchToTimeValue; }
            set { defaultSearchToTimeValue = value; }
        }

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
        public DBBinaryImage()
        {
            RowSpan = 2;
        }
        [DefaultValue(1)]
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
        public DBPathImage()
        {
            this.ColSpan = 2;
        }

        [DefaultValue(2)]
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
