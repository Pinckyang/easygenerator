using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper.Info;
using System.Data;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Builder;

namespace EasyGenerator.Studio.DbHelper
{
    public abstract class Driver
    {
        private Domain model;


        public Driver(ConnectionInfo connectionInfo)
            : base()
        {
            if (connectionInfo == null)
                throw new ArgumentNullException("ConnectionInfo is null.");

            this.model = new Domain(connectionInfo);

        }

        public ConnectionInfo ConnectionInfo
        {
            get { return model.ConnectionInfo; }
        }

        public abstract IDbConnection CreateConnection();

        public abstract IDbCommand CreateCommand();

        public abstract ISchemaExtractor CreateExtractor();
    }
}
