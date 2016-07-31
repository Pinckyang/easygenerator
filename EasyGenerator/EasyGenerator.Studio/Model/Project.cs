using System;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;
using EasyGenerator.Studio.Model.DB;
using EasyGenerator.Studio.Model.UI;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNodeAttribute(ImageIndex=0)]
    [XmlRoot("Project")]
    public class Project:ContextObject,ICloneable
    {
        //private string name;
        //private string caption;
        //private string description;

        public Project()
            :base(null)
        {
            Database = new Database(this);
            Ui = new GUI(this);
        }

        public Project(ContextObject owner)
            :base(owner)
        {
             Database=new Database(this);
             Ui=new GUI(this);
        }

        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
        [XmlAttribute("Name")]
        public string Name
        {
            get;
            set;
        }

        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
        [XmlAttribute("Caption")]
        public string Caption
        {
            get;
            set;
        }


        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
        [XmlAttribute("Description")]
        public string Description
        {
            get;
            set;
        }

        [XmlElement("Database")]
        [BrowsableAttribute(false)]
        [UiNodeInvisible()]
        public Database Database
        {
            get;
            set;
        }

        [XmlElement("Ui")]
        [BrowsableAttribute(false)]
        public GUI Ui
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Caption))
            {
                return this.Caption;
            }
            return this.Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
