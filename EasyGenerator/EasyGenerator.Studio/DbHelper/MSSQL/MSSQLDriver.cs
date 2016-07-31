using System;
using System.Collections.Generic;
using System.Text;
//using EasyGenerator.Model;
using System.Data.SqlClient;
using EasyGenerator.Studio.Model;
using System.Data;

namespace EasyGenerator.Studio.DbHelper.MSSQL
{
    public class MSSQLDriver: Driver
    {
        public MSSQLDriver(ConnectionInfo connectionInfo)
            : base(connectionInfo)
        {

        }

        public override IDbCommand CreateCommand()
        {
            SqlCommand command =  new SqlCommand();
            command.Connection = (SqlConnection)this.CreateConnection();
            return command;
        }

        public override IDbConnection CreateConnection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Data Source={0};Initial Catalog={1};", ConnectionInfo.Host, ConnectionInfo.Database);
            if (!String.IsNullOrEmpty(ConnectionInfo.User))
            {
                sb.AppendFormat("User ID={0};Password={1};", ConnectionInfo.User, ConnectionInfo.Password);
            }
            else
            {
                sb.Append("Integrated Security=SSPI;Persist Security Info=False;");
            }
            return new SqlConnection(sb.ToString());
        }

        public override ISchemaExtractor CreateExtractor()
        {
            return new MSSQLSchemaExtractor(this);
        }
    }
}
