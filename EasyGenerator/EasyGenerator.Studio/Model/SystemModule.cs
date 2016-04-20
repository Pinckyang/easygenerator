using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Utils;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    public class SystemModule : ContextObject,ICloneable
    {
        //private ContextObjectDictionary<string, Module> modules = null;
        private string name = "SystemModule";
        private string caption = "功能模块";
        private string description = "功能模块";

        public SystemModule()
        {
           Modules= new ContextObjectDictionary<string, Module>(this);
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [ReadOnly(true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [ReadOnly(true)]
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        [CategoryAttribute("界面")]
        [UiNodeInvisibleAttribute()]
        [ReadOnly(true)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        public ContextObjectDictionary<string, Module> Modules
        {
            get;// { return modules; }
            set;// { modules = value ; }
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
