using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    public class SearchModeControl:ContextObject
    {
        [XmlIgnore]
        public override ContextObject Owner
        {
            get
            {
                return base.Owner;
            }
            set
            {
                base.Owner = value;
            }
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
    public class SearchDateSingleControl : SearchModeControl
    {
        private string datetime;

        [TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("Datetime")]
        public string Datetime
        {
            get { return datetime; }
            set 
            { 
                datetime = value; 
                
            }
        }

    }

    [TypeConverter(typeof(PropertySorter))]
    public class SearchDateRangeControl : SearchModeControl
    {
        private string startDatetime;

        [PropertyOrder(1)]
        [TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("StartDatetime")]
        public string StartDatetime
        {
            get { return startDatetime; }
            set { startDatetime = value; }
        }
        private string endDatetime;

        [PropertyOrder(2)]
        [TypeConverter(typeof(DateTimeDefaultConverter))]
        [XmlAttribute("EndDatetime")]
        public string EndDatetime
        {
            get { return endDatetime; }
            set { endDatetime = value; }
        }
    }
}
