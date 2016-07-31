using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper;
using System.Runtime.Serialization;

namespace EasyGenerator.Studio.Builder
{
    [Serializable()]
    public class Domain 
    {


        private ConnectionInfo connectionInfo;


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

        public ConnectionInfo ConnectionInfo
        {
            get { return connectionInfo; }
        }
    }
}
