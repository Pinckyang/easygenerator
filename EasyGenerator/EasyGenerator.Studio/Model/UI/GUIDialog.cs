using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;
using System.Xml.Serialization;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.Model.UI
{
    [UiNode(ImageIndex = 4)]
    [XmlRoot("GUIDialog")]
    public class GUIDialog : ContextObject, ICloneable
    {
        private string name;
        private string caption;
        private string description;
        private string resultTableName;
        private bool multiSelect = false;


        public GUIDialog(ContextObject owner)
            :base(owner)
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

        public object Clone()
        {

            return this.MemberwiseClone();
        }
    }
}
