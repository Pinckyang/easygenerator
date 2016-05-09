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
    public class ContextObject : INotifyPropertyChanged//, IXmlSerializable
    {
        private ContextObject owner = null;

        [BrowsableAttribute(false)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        [XmlIgnore()]
        public virtual ContextObject Owner
        {
            get { return owner; }
            set
            {
                owner = value;
            }
        }

        //public string Name
        //{
        //    get;
        //    set;
        //}

        public ContextObject GetRoot()
        {
            if (this.owner != null)
            {
                return this.owner.GetRoot(); 
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

        //public void ReadXml(XmlReader reader)
        //{
        //   // this.ReadXml(reader);
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    //this.WriteXml(writer);  
        //}

        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}
    }
}
