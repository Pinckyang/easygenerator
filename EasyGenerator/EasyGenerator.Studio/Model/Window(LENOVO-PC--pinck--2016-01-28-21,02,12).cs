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
            Entities = new ContextObjectDictionary<string, EntityInfo>(this);
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
                foreach (KeyValuePair<string, EntityInfo> kv in Entities)
                {
                    kv.Value.Caption = Caption;
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
        public ContextObjectDictionary<string, EntityInfo> Entities
        {
            get;//{ return enities; }
            set;// { enities = caption; }
        }

        [UiNodeInvisibleAttribute(),DefaultValue(false)]
        [XmlElement("AllowAdd")]
        public bool AllowAdd
        {
            get { return allowAdd; }
            set 
            {
                allowAdd = value;
                foreach (KeyValuePair<string, EntityInfo> entity in Entities)
                {
                    entity.Value.DBViewControl.AllowAdd = value;
                    //if (!caption)
                    //{
                    //    PropertyHelper.SetPropertyReadOnly(entity.Caption.DBViewControl, "AllowAdd", false);
                    //}
                    //else
                    //{
                    //    PropertyHelper.SetPropertyReadOnly(entity.Caption.DBViewControl, "AllowAdd", true);
                    //}
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
                foreach (KeyValuePair<string, EntityInfo> entity in Entities)
                {
                    entity.Value.DBViewControl.AllowEdit = value;
                    //if (!caption)
                    //{
                    //    PropertyHelper.SetPropertyReadOnly(entity.Caption.DBViewControl, "AllowEdit", false);
                    //}
                    //else
                    //{
                    //    PropertyHelper.SetPropertyReadOnly(entity.Caption.DBViewControl, "AllowEdit", true);
                    //}
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
                foreach (KeyValuePair<string, EntityInfo> entity in Entities)
                {
                    entity.Value.DBViewControl.AllowDelete = value;
                    //if (!caption)
                    //{
                    //    PropertyHelper.SetPropertyReadOnly(entity.Caption.DBViewControl, "AllowDelete", false);
                    //}
                    //else
                    //{
                    //    PropertyHelper.SetPropertyReadOnly(entity.Caption.DBViewControl, "AllowDelete", true);
                    //}
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

                //foreach (KeyValuePair<string, EntityInfo> entity in enities)
                //{
                //    foreach (KeyValuePair<string, ColumnInfo> column in entity.Caption.Columns)
                //    {
                //        if (!caption)
                //        {
                //            PropertyHelper.SetPropertyReadOnly(column.Caption.DBControl, "DefaultSearchValue", false);
                //        }
                //        else
                //        {
                //            PropertyHelper.SetPropertyReadOnly(column.Caption.DBControl, "DefaultSearchValue", true);
                //        }
                //    }
                //}


                NotifyPropertyChanged(this, "AllowSearch");
            }
        }

        [UiNodeInvisibleAttribute(), DefaultValue(false)]
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
        //public Window(ContextObject owner)
        //    :base(owner)
        //{

        //}


        public object Clone()
        {
            //MemoryStream stream = new MemoryStream();
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(stream, this);
            //stream.Position = 0;
            //return formatter.Deserialize(stream);
            return this.MemberwiseClone();
        }
    }
}
