using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;
using System.ComponentModel;
using System.Xml.Serialization;
using EasyGenerator.Studio.Utils;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    [UiNode(ImageIndex = 4)]
    [XmlRoot("GUIModule")]
    public class GUIWindow : ContextObject,ICloneable
    {
        private bool allowAdd=false;
        private bool allowEdit=false;
        private bool allowDelete=false;
        private bool allowSearch=false;
        private bool allowPrint=false;

        public GUIWindow(ContextObject owner)
            :base(owner)
        {
            MasterViews = new ContextObjectList<GUIEntityInfo>(this);
        }


        [UiNodeInvisibleAttribute()]
        [XmlElement]
        public string Name
        {
            get;
            set;
        }
        [UiNodeInvisibleAttribute()]
        [XmlElement]
        public string Caption
        {
            get;
            set;
        }

        [UiNodeInvisibleAttribute()]
        [XmlElement]
        public string Description
        {
            get;
            set;
        }
        
        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        [XmlElement]
        public List<GUIEntityInfo> MasterViews
        {
            get;
            set;
        }

        [UiNodeInvisibleAttribute(),DefaultValue(false)]
        [XmlElement]
        public bool AllowAdd
        {
            get { return allowAdd; }
            set 
            {
                allowAdd = value;
                foreach (GUIEntityInfo entity in MasterViews)
                {
                    //entity.DBViewControl.AllowAdd = value;
                }

                NotifyPropertyChanged(this, "AllowAdd");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement]
        public bool AllowEdit
        {
            get { return allowEdit; }
            set 
            { 
                allowEdit = value;
                foreach (GUIEntityInfo entity in MasterViews)
                {
                    //entity.DBViewControl.AllowEdit = value;
                }

                NotifyPropertyChanged(this, "AllowEdit");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement]
        public bool AllowDelete
        {
            get { return allowDelete; }
            set 
            {
                allowDelete = value;
                foreach (GUIEntityInfo entity in MasterViews)
                {
                    //entity.DBViewControl.AllowDelete = value;
                }

                NotifyPropertyChanged(this, "AllowDelete");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
        [XmlElement]
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
        [XmlElement]
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
