using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper;
using System.Runtime.Serialization;

namespace EasyGenerator.Studio.Builder
{
    [Serializable()]
    public class Domain : ISerializable
    {
      // public OnRemoveObjectDelegate OnRemoveTable;

        private ConnectionInfo connectionInfo;
        //private IDictionary<String, ControlBase> controls;

        private Domain()
        {
        }

        public Domain(ConnectionInfo connectionInfo)
        {
            if (connectionInfo == null)
            {
                throw new ArgumentNullException("connectionInfo");
            }
            this.connectionInfo = connectionInfo;


        }

        public Domain(SerializationInfo Info, StreamingContext ctxt)

        {
            this.connectionInfo = (ConnectionInfo)Info.GetValue("connectionInfo", typeof(ConnectionInfo));
            //this.controls = (IDictionary<String, ControlBase>)Info.GetValue("clientEditors", typeof(IDictionary<String, ControlBase>));
        }

        private void LoadProfiles()
        {
            //ControlBase clientProfile = new TextBox();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new CheckBox();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new ComboBox();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new Image();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new ListBox();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new OptionButton();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new Popup();
            //this.controls.Add(clientProfile.Name, clientProfile);

            //clientProfile = new TextBox("DateTime");
            //((TextBox)clientProfile).IsDateTime = true;
            //this.controls.Add(clientProfile.Name, clientProfile);

        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo Info, StreamingContext ctxt)
        {
           // return base.GetObjectData(Info, ctxt);

            //Info.AddValue("name", this.name);
            //Info.AddValue("caption", this.caption);
            //Info.AddValue("code", this.code);
            //Info.AddValue("description", this.description);
            //Info.AddValue("comment", this.comment);

            //Info.AddValue("connectionInfo", this.connectionInfo);
            //Info.AddValue("clientEditors", this.controls);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ConnectionInfo ConnectionInfo
        {
            get { return connectionInfo; }
        }

        //public IDictionary<String, ControlBase> Controls
        //{
        //    get { return controls; }
        //}

        #endregion

        //public bool RemoveTable(Table table)
        //{
        //    if (this.connectionInfo.RemoveTable(table))
        //    {
        //        if (this.OnRemoveTable != null)
        //        {
        //            OnRemoveTable(this, table);
        //        }
        //        return true;
        //    }
        //    return false;
        //}
    }
}
