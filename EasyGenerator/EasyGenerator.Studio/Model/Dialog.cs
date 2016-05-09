using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [UiNode(ImageIndex = 4)]
    [XmlRoot("Dialog")]
    public class Dialog : ContextObject, ICloneable
    {
        private string name;
        private string caption;
        private string description;
        private string resultTableName;
        private bool multiSelect = false;


        public Dialog()
        {
            Entities = new ContextObjectList<EntityInfo>(this);
            
        }

        [UiNodeInvisibleAttribute()]
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
        [UiNodeInvisibleAttribute()]
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

        [UiNodeInvisibleAttribute()]
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

        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlElement("Entities")]
        public List<EntityInfo> Entities
        {
            get;
            set;

        }

        [UiNodeInvisibleAttribute()]
        [XmlElement("ResultTableName")]
        public string ResultTableName
        {
            get { return resultTableName; }
            set { resultTableName = value; }
        }

        [UiNodeInvisibleAttribute()]
        [DefaultValue(false)]
        [XmlElement("MultiSelect")]
        public bool MultiSelect
        {
            get { return multiSelect; }
            set { multiSelect = value; }
        }


        public override string ToString()
        {
            return this.Caption;
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
