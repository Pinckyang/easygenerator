﻿using System;
using System.ComponentModel;
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

        public Project()
            :base(null)
        {

        }

        public Project(ContextObject owner)
            :base(owner)
        {
             Database=new Database(this);
             Ui=new UI(this);
        }

        [CategoryAttribute("设计"),DefaultValueAttribute("")]
        [UiNodeInvisible()]
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

        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
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

        
        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [UiNodeInvisible()]
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
        public UI Ui
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
