using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    public class CommonModule:ContextObject,ICloneable
    {
        private string name = "CommonModule";
        private string caption = "通用模块";
        private string description = "通用模块";
        private ContextObjectDictionary<string, Dialog> dialogs = null;

        public CommonModule()
        {
            dialogs = new ContextObjectDictionary<string, Dialog>(this);
        }

        [ReadOnly(true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [ReadOnly(true)]
        public string Caption
        {
            get { return caption; }
            set { name = value; }
        }

        [ReadOnly(true)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public override string ToString()
        {
            return this.Caption;
        }


        [BrowsableAttribute(false)]
        [UiNodeAttribute()]
        [ReadOnly(true)]
        public ContextObjectDictionary<string, Dialog> Dialogs
        {
            get { return dialogs; }
            set { dialogs = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
