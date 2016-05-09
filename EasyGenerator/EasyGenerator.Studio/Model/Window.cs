using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;
using System.ComponentModel;
using System.Xml.Serialization;
using EasyGenerator.Studio.Utils;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [UiNode(ImageIndex = 4)]
    [XmlRoot("Module")]
    public class Window : ContextObject,ICloneable
    {
        private string name;
        private string caption;
        private string description;
        
        private bool allowAdd=false;
        private bool allowEdit=false;
        private bool allowDelete=false;
        private bool allowSearch=false;
        private bool allowPrint=false;

        public Window()
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

                NotifyPropertyChanged(this,"Name");
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
                foreach (EntityInfo entity in Entities)
                {
                    entity.Caption = Caption;
                }

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

        [UiNodeInvisibleAttribute(),DefaultValue(false)]
        [XmlElement("AllowAdd")]
        public bool AllowAdd
        {
            get { return allowAdd; }
            set 
            {
                allowAdd = value;
                foreach (EntityInfo entity in Entities)
                {
                    entity.DBViewControl.AllowAdd = value;
                }

                NotifyPropertyChanged(this, "AllowAdd");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement("AllowEdit")]
        public bool AllowEdit
        {
            get { return allowEdit; }
            set 
            { 
                allowEdit = value;
                foreach (EntityInfo entity in Entities)
                {
                    entity.DBViewControl.AllowEdit = value;
                }

                NotifyPropertyChanged(this, "AllowEdit");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement("AllowDelete")]
        public bool AllowDelete
        {
            get { return allowDelete; }
            set 
            {
                allowDelete = value;
                foreach (EntityInfo entity in Entities)
                {
                    entity.DBViewControl.AllowDelete = value;
                }

                NotifyPropertyChanged(this, "AllowDelete");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement("AllowSearch")]
        public bool AllowSearch
        {
            get { return allowSearch; }
            set 
            { 
                allowSearch = value;

                NotifyPropertyChanged(this, "AllowSearch");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement("AllowPrint")]
        public bool AllowPrint
        {
            get { return allowPrint; }
            set 
            { 
                allowPrint = value;
                NotifyPropertyChanged(this, "AllowPrint");
            }
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
