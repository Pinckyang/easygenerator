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
    /*[Serializable()]
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
    }*/











    

    

   

   

   

   

    

   




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
