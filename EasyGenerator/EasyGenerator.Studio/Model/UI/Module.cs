using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNode(ImageIndex=3)]
    [XmlRoot("Module")]
    public class Module : ContextObject,ICloneable
    {
        //private string name;
        //private string caption;
        //private string description;

        public Module(ContextObject owner)
            : base(owner)
        {
            Windows=new ContextObjectList<Window>(this);
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [XmlElement("Name")]
        public string Name
        {
            get;
            set;
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [XmlElement("Caption")]
        public string Caption
        {
            get;
            set;
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [XmlElement("Description")]
        public string Description
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlElement("Windows")]
        public List<Window> Windows
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Caption;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
