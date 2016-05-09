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
    public class DBViewControl:ContextObject,ICloneable
    {
        private string name;
        private string caption;
        private string description;
        private bool allowAdd=false;
        private bool allowEdit=false;
        private bool allowDelete=false;
        //private object owner;

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
        public string Caption
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
                    entity.DBControl.AllowAdd = value;

                    //foreach (KeyValuePair<string, ReferenceInfo> reference in entity.Caption.References)
                    //{
                    //    if (reference.Caption.ReferenceTable != null)
                    //    {
                    //        reference.Caption.ReferenceTable.DBViewControl.AllowAdd = caption;
                    //    }
                    //}
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
                    entity.DBControl.AllowEdit = value;

                    //foreach (KeyValuePair<string, ReferenceInfo> reference in entity.Caption.References)
                    //{
                    //    if (reference.Caption.ReferenceTable != null)
                    //    {
                    //        reference.Caption.ReferenceTable.DBViewControl.AllowEdit = caption;
                    //    }
                    //}
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
            //MemoryStream stream = new MemoryStream();
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(stream, this);
            //stream.Position = 0;
            //return formatter.Deserialize(stream);
            return this.MemberwiseClone();
        }
    }

    [Serializable()]
    public class DBGridView : DBViewControl,ICloneable
    {
        public override string ToString()
        {
            return string.Empty;
        }
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

    [Serializable()]
    public class DBTreeView : DBViewControl,ICloneable
    {
        private string keyField;
        private string parentField;
        private string rootValue;
        

        [CategoryAttribute("数据库"), DefaultValueAttribute(""),TypeConverter(typeof(ClientTreeViewStringConverter))]
        [XmlAttribute("KeyField")]
        public string KeyField
        {
            get { return keyField; }
            set 
            { 
                keyField = value;
                NotifyPropertyChanged(this, "KeyField");
            }
        }

        [CategoryAttribute("数据库"), DefaultValueAttribute(""), TypeConverter(typeof(ClientTreeViewStringConverter))]
        [XmlAttribute("ParentField")]
        public string ParentField
        {
            get { return parentField; }
            set 
            { 
                parentField = value;
                NotifyPropertyChanged(this, "ParentField");
            }
        }
        [CategoryAttribute("数据库"), DefaultValueAttribute("")]
        [XmlAttribute("RootValue")]
        public string RootValue
        {
            get { return rootValue; }
            set 
            { 
                rootValue = value;
                NotifyPropertyChanged(this, "RootValue");
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
