/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

using System;
using System.Collections.Generic;
using System.Text;
//using EasyGenerator.Model;
using System.Data.SqlClient;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.DbHelper.MSSQL
{
    public class MSSQLDriver: Driver
    {
        public MSSQLDriver(ConnectionInfo connectionInfo,Project project)
            : base(connectionInfo,project)
        {

        }

        /// <summary>
        /// return the MSSQLExtractor
        /// </summary>
        public override OLESchemaExtractor Extractor
        {
            get
            {
                if (extractor == null)
                {
                    extractor = new MSSQL2000SchemaExtractor(this,this.Project);
                }
                return extractor;
            }
        }

        public override System.Data.IDbConnection CreateConnection()
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

        public override void ConfigureConnection(System.Data.IDbConnection connection)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public override void TestConnection(System.Data.IDbConnection connection)
        {
           throw new Exception("The method or operation is not implemented.");
        }
    }
}
