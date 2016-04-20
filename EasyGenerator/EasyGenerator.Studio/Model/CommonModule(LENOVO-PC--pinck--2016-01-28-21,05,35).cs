﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlRoot("CommonModule")]
    public class CommonModule:ContextObject,ICloneable
    {
        private string name = "CommonModule";
        private string caption = "通用模块";
        private string description = "通用模块";

        public CommonModule()
        {
            dialogs = new ContextObjectDictionary<string, Dialog>(this);
        }

        [ReadOnly(true)]
        [XmlElement("Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [ReadOnly(true)]
        [XmlElement("Caption")]
        public string Caption
        {
            get { return caption; }
            set { name = value; }
        }

        [ReadOnly(true)]
        [XmlElement("Description")]
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
        [XmlElement("Dialogs")]
        public ContextObjectDictionary<string, Dialog> Dialogs
        {
            get;
            set;
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
}