using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model.UI
{
    public class DBTreeView : DBView, ICloneable
    {
        private string keyField;
        private string parentField;
        private string rootValue;

        public DBTreeView(ContextObject owner)
            : base(owner)
        {
        }


        [CategoryAttribute("数据库"), DefaultValueAttribute(""), TypeConverter(typeof(ClientTreeViewStringConverter))]
        [XmlAttribute("KeyField")]
        public string KeyField
        {
            get { return keyField; }
            set
            {
                keyField = value;
                NotifyPropertyChanged(this, "KeyField");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(""), TypeConverter(typeof(ClientTreeViewStringConverter))]
        [XmlAttribute("ParentField")]
        public string ParentField
        {
            get { return parentField; }
            set
            {
                parentField = value;
                NotifyPropertyChanged(this, "ParentField");
            }
        }
        [CategoryAttribute("数据库"), DefaultValueAttribute("")]
        [XmlAttribute("RootValue")]
        public string RootValue
        {
            get { return rootValue; }
            set
            {
                rootValue = value;
                NotifyPropertyChanged(this, "RootValue");
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
}
