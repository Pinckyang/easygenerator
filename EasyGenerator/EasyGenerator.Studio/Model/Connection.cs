using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DefaultPropertyAttribute("DataSource")]
    [XmlRoot("Connection")]
    public class Connection : ContextObject,ICloneable
    {
        private string dataSource;
        private string initialCatalog;
        private string userID;
        private string password;
        private bool integratedSecurity = true;

        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [XmlElement("DataSource")]
        public string DataSource
        {
            get { return dataSource; }
            set 
            {
                dataSource = value;
                NotifyPropertyChanged(this, "DatabaseType");
            }
        }
        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [XmlElement("InitialCatalog")]
        public string InitialCatalog
        {
            get { return initialCatalog; }
            set 
            { 
                initialCatalog = value;
                NotifyPropertyChanged(this, "InitialCatalog");
            }
        }
        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [XmlElement("UserID")]
        public string UserID
        {
            get { return userID; }
            set 
            { 
                userID = value;
                NotifyPropertyChanged(this, "UserID");
            }
        }
        [CategoryAttribute("设计"), DefaultValueAttribute("")]
        [XmlElement("Password")]
        public string Password
        {
            get { return password; }
            set 
            {
                password = value;
                NotifyPropertyChanged(this, "Password");
            }
        }
        [CategoryAttribute("设计"), DefaultValueAttribute(true)]
        [XmlElement("IntegratedSecurity")]
        public bool IntegratedSecurity
        {
            get { return integratedSecurity; }
            set 
            { 
                integratedSecurity = value;
                NotifyPropertyChanged(this, "IntegratedSecurity");
            }
        }

        //public Connection(ContextObject owner)
        //    :base(owner)
        //{
        //}

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
