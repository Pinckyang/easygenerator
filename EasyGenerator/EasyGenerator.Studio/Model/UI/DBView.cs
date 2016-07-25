using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyGenerator.Studio.Model.UI;
using System.ComponentModel;
using System.Xml.Serialization;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.Model.UI
{
 [Serializable()]
    public class DBView:GUIEntityInfo,ICloneable
    {
        private string name;
        private string caption;
        private string description;
        private bool allowAdd=false;
        private bool allowEdit=false;
        private bool allowDelete=false;

        public DBView(ContextObject owner)
            : base(owner)
        {
        }

        [CategoryAttribute("显示"), DefaultValueAttribute("")]
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

        [CategoryAttribute("显示"), DefaultValueAttribute("")]
        [XmlAttribute("Caption")]
        public new string Caption
        {
            get { return caption; }
            set 
            { 
                caption = value;
                NotifyPropertyChanged(this, "Caption");
            }
        }
        [CategoryAttribute("显示"), DefaultValueAttribute("")]
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

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute("AllowAdd")]
        public bool AllowAdd
        {
            get { return allowAdd; }
            set 
            {
                allowAdd = value;
                foreach (ColumnInfo entity in ((EntityInfo)this.Owner).Columns)
                {
                    //TODO:entity.DBControl.AllowAdd = value;
                }
                NotifyPropertyChanged(this, "AllowAdd");
            }
        }

        [CategoryAttribute("显示"), DefaultValue(false)]
        [XmlAttribute("AllowEdit")]
        public bool AllowEdit
        {
            get { return allowEdit; }
            set 
            { 
                allowEdit = value;
                foreach (ColumnInfo entity in ((EntityInfo)this.Owner).Columns)
                {
                    //TODO:entity.DBControl.AllowEdit = value;
                }

                NotifyPropertyChanged(this, "AllowEdit");
            }
        }

        [CategoryAttribute("显示"),DefaultValue(false)]
        [XmlAttribute("AllowDelete")]
        public bool AllowDelete
        {
            get { return allowDelete; }
            set 
            {
                allowDelete = value;

                //foreach (KeyValuePair<string, ColumnInfo> entity in ((EntityInfo)this.Owner).Columns)
                //{
                //    foreach (KeyValuePair<string, ReferenceInfo> reference in entity.Caption.References)
                //    {
                //        if (reference.Caption.ReferenceTable != null)
                //        {
                //            reference.Caption.ReferenceTable.DBViewControl.AllowDelete = caption;
                //        }
                //    }
                //}
                NotifyPropertyChanged(this, "AllowDelete");
            }
        }



        public override string ToString()
        {
            return string.Empty;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
