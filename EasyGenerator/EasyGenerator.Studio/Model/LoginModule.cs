using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [XmlRoot("LoginModule")]
    public class LoginModule : ContextObject,ICloneable
    {
        private string name = "LoginModule";
        private string caption = "登录模块";
        private string description = "登录模块";
        private string tableName;
        private string accountField;
        private string passwordField;

        [CategoryAttribute("界面")]
        [XmlElement("Name")]
        [ReadOnly(true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [CategoryAttribute("界面")]
        [XmlElement("Caption")]
        [ReadOnly(true)]
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        [CategoryAttribute("界面")]
        [XmlElement("Description")]
        [ReadOnly(true)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [CategoryAttribute("关联表")]
        [UiNodeInvisibleAttribute()]
        [TypeConverter(typeof(TablesConverter))]
        [XmlElement("TableName")]
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        [CategoryAttribute("关联字段")]
        [UiNodeInvisibleAttribute()]
        [TypeConverter(typeof(ColumnsFromTableNameConverter))]
        [XmlElement("AccountField")]
        public string AccountField
        {
            get { return accountField; }
            set { accountField = value; }
        }
         [CategoryAttribute("关联字段")]
        [UiNodeInvisibleAttribute()]
        [TypeConverter(typeof(ColumnsFromTableNameConverter))]
        [XmlElement("PasswordField")]
        public string PasswordField
        {
            get { return passwordField; }
            set { passwordField = value; }
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
