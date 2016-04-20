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
        private Project project;

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }
        protected OLESchemaExtractor extractor;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="connectionInfo">Information about default connection.</param>
        /// <param name="domain">Model, to which this driver belongs.</param>
        public Driver(ConnectionInfo connectionInfo,Project project)
            : base()
        {
            if (connectionInfo == null)
                throw new ArgumentNullException("ConnectionInfo is null.");

            this.model = new Domain(connectionInfo);
            this.project = project;
        }

        /// <summary>
        /// Information about this driver.
        /// </summary>
        public ConnectionInfo ConnectionInfo
        {
            get { return model.ConnectionInfo; }
        }

        /// <summary>
        /// Model for the Driver
        /// </summary>
        public Domain Model
        {
            get { return model; }
        }

        /// <summary>
        /// Creates new IDbConnection instance.
        /// </summary>
        /// <returns>Connection instance.</returns>
        public abstract IDbConnection CreateConnection();

        /// <summary>
        /// return the extractor
        /// </summary>
        public abstract OLESchemaExtractor Extractor
        {
            get;
        }

        /// <summary>
        /// Configures IDbConnection.
        /// </summary>
        /// <param name="connection">Connection to configure.</param>
        public abstract void ConfigureConnection(IDbConnection connection);

        /// <summary>
        /// Test IDbConnection
        /// </summary>
        /// <param name="connection">Connection to test.</param>
        public abstract void TestConnection(IDbConnection connection);

        /// <summary>
        /// Creates, opens and configures new <see cref="IDbConnection"/> instance.
        /// </summary>
        /// <returns>Connection instance.</returns>
        public IDbConnection OpenConnection()
        {
            IDbConnection connection = CreateConnection();
            connection.Open();
            ConfigureConnection(connection);
            return connection;
        }

    }
}
