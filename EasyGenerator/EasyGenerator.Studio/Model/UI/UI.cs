using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    [DefaultPropertyAttribute("SystemModule")]
    [UiNode(Text="界面设计",ImageIndex=1)]
    [XmlRoot("UI")]
    public class UI : ContextObject,ICloneable
    {
        public UI(ContextObject owner)
            :base(owner)
        {
            LoginModule = new LoginModule(this);
            CommonModule = new CommonModule(this);
            SystemModule = new SystemModule(this);
        }

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [UiNode(Text = "登录模块", ImageIndex = 2)]
        [XmlElement("LoginModule")]
        public LoginModule LoginModule
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
        [XmlElement("SystemModule")]
        public SystemModule SystemModule
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
