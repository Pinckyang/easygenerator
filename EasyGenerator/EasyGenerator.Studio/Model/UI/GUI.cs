using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    [DefaultPropertyAttribute("GUISystemModule")]
    [UiNode(Text="界面设计",ImageIndex=1)]
    [XmlRoot("GUI")]
    public class GUI : ContextObject,ICloneable
    {
        public GUI(ContextObject owner)
            :base(owner)
        {
            LoginModule = new GUILoginModule(this);
            CommonModule = new CommonModule(this);
            SystemModule = new GUISystemModule(this);
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [UiNode(Text = "登录模块", ImageIndex = 2)]
        [XmlElement("GUILoginModule")]
        public GUILoginModule LoginModule
        {
            get;
            set;
        }

        [BrowsableAttribute(true)]
        [UiNode(Text = "通用模块", ImageIndex = 2)]
        [XmlElement("CommonModule")]
        public CommonModule CommonModule
        {
            get;
            set;
        }


        [UiNode(Text = "功能模块", ImageIndex = 2)]
        [XmlElement("GUISystemModule")]
        public GUISystemModule SystemModule
        {
            get;
            set;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
