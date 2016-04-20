using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    public class LoginModule : ContextObject,ICloneable
    {
        private string name = "LoginModule";
        private string caption = "登录模块";
        private string description = "登录模块";
        private EntityInfo table;

        public EntityInfo Table
        {
            get { return table; }
            set { table = value; }
        }
        private string accountField;

        public string AccountField
        {
            get { return accountField; }
            set { accountField = value; }
        }
        private string passwordField;

        public string PasswordField
        {
            get { return passwordField; }
            set { passwordField = value; }
        }

        [CategoryAttribute("界面")]
        public string Name
        {
            get { return name; }
        }

        [CategoryAttribute("界面")]
        public string Caption
        {
            get { return caption; }
        }

        [CategoryAttribute("界面")]
        public string Description
        {
            get { return description; }
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
