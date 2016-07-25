using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    public class GUISystemModule : ContextObject,ICloneable
    {
        private string name = "GUISystemModule";
        private string caption = "功能模块";
        private string description = "功能模块";

        public GUISystemModule(ContextObject owner)
            :base(owner)
        {
           Modules= new ContextObjectList<GUIModule>(this);
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [ReadOnly(true)]
        [XmlAttribute("Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [ReadOnly(true)]
        [XmlAttribute("Caption")]
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [ReadOnly(true)]
        [XmlAttribute("Description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlElement("Description")]
        public List<GUIModule> Modules
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
