using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNodeAttribute(ImageIndex=0)]
    [XmlRoot("Project")]
    public class Project:ContextObject,ICloneable
    {
        private string name;
        private string caption;
        private string description;
        private Database database=new Database();
        private UI ui=new UI();

        public Project()
        {
            database.Owner = this;
            ui.Owner = this;
           // ProjectAccesser.SetProject(this);
        }

        [CategoryAttribute("设计"),DefaultValueAttribute("")]
        [UiNodeInvisible()]
        [XmlElement("Name")]
        public string Name
        {
            get { return name; }
            set
            { 
                name = value;
                NotifyPropertyChanged(this, "Name");
            }
        }

        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
        [XmlElement("Caption")]
        public string Caption
        {
            get { return caption; }
            set 
            { 
                caption = value;
                NotifyPropertyChanged(this, "Caption");
            }
        }

        
        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
        [XmlElement("Description")]
        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                NotifyPropertyChanged(this, "Description");
            }
        }

        [XmlElement("Database")] 
        [BrowsableAttribute(false)]
        [UiNodeInvisible()]
        public Database Database
        {
            get { return database; }
            set { database = value; }
        }

        [XmlElement("Ui")] 
        [BrowsableAttribute(false)]
        public UI Ui
        {
            get { return ui; }
            set { ui = value; }
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
