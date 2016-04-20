using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("SystemModule")]
    [UiNode(Text="界面设计",ImageIndex=1)]
    [XmlRoot("UI")]
    public class UI : ContextObject,ICloneable
    {
        private LoginModule loginModule=new LoginModule();

        [CategoryAttribute("数据库")]
        [BrowsableAttribute(true)]
        [UiNode(Text="登录模块",ImageIndex=2)]
        [XmlElement("LoginModule")]
        public LoginModule LoginModule
        {
            get { return loginModule; }
            set { loginModule = value; }
        }
        private CommonModule commonModule=new CommonModule();

        [BrowsableAttribute(true)]
        [UiNode(Text = "通用模块", ImageIndex = 2)]
        [XmlElement("CommonModule")]
        public CommonModule CommonModule
        {
            get { return commonModule; }
            set { commonModule = value; }
        }
        private SystemModule systemModule=new SystemModule();

        [UiNode(Text = "功能模块", ImageIndex = 2)]
        [XmlElement("SystemModule")]
        public SystemModule SystemModule
        {
            get { return systemModule; }
            set { 
                systemModule = value;
                systemModule.Owner = this;
                NotifyPropertyChanged(this, "SystemModule");
            }
        }

        public UI()
        {
            loginModule.Owner = this;
            commonModule.Owner = this;
            systemModule.Owner = this;
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
