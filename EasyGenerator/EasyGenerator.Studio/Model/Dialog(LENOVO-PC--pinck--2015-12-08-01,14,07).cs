using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;

namespace EasyGenerator.Studio.Model
{
    [UiNode(ImageIndex = 4)]
    public class Dialog : ContextObject, ICloneable
    {
        private string name;
        private string caption;
        private string description;
        private ContextObjectDictionary<string, EntityInfo> entities=null;
        private string resultTableName;
        private bool multiSelect = false;


        public Dialog()
        {
            entities = new ContextObjectDictionary<string, EntityInfo>(this);
        }

        [UiNodeInvisibleAttribute()]
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
        public ContextObjectDictionary<string, EntityInfo> Entities
        {
            get { return entities; }

        }

        public string ResultTableName
        {
            get { return resultTableName; }
            set { resultTableName = value; }
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
