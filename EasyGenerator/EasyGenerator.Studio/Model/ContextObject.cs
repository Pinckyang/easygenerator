using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    public abstract class ContextObject : INotifyPropertyChanged//, IXmlSerializable
    {

        [BrowsableAttribute(false)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlIgnore()]
        public virtual ContextObject Owner
        {
            get;
            set;
        }
        //private ContextObject()
        //{
        //}
        public ContextObject(ContextObject owner)
        {
            this.Owner = owner;
        }

        public ContextObject GetRoot()
        {
            if (this.Owner != null)
            {
                return this.Owner.GetRoot(); 
            }
            return this;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(object obj,string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(obj, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
