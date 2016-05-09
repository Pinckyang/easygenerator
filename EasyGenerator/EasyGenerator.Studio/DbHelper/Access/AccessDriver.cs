//using System;
//using System.Collections.Generic;
//using System.Text;
//using EasyGenerator.Model;
//using System.Data.OleDb;
//using EasyGenerator.Studio.DbHelper;

//namespace EasyGenerator.Studio.DbHelpere.Access
//{
//    internal class AccessDriver : Driver
//    {
//        /// <summary>
//        /// msaccess://localhost/C:\\SampleDB.mdb
//        /// Microsoft.Jet.OLEDB.4.0://localhost/C:\\SampleDB.mdb
//        /// </summary>
//        /// <param name="connectionInfo"></param>
//        public AccessDriver(ConnectionInfo connectionInfo)
//            : base(connectionInfo)
//        {

//        }

//        public override System.Data.IDbConnection CreateConnection()
//        {
//            StringBuilder sb = new StringBuilder();

//            //Open connection to Access database:
//            //"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\App1\Your_Database_Name.mdb; User Id=admin; Password=" 

//            //Open connection to password protected Access database:
//            //"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\App1\Your_Database_Name.mdb; Jet OLEDB:Database Password=Your_Password" 

//            sb.AppendFormat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", ConnectionInfo.Database);

//            if (!String.IsNullOrEmpty(ConnectionInfo.Password))
//            {
//                sb.AppendFormat("Jet OLEDB:Database Password={0}", ConnectionInfo.Password);
//            }
//            else
//            {
//                sb.AppendFormat("User Id={0}; Password=", ConnectionInfo.User);
//            }

//            return new OleDbConnection(sb.ToString());
//        }

//        public override OLESchemaExtractor Extractor
//        {
//            get
//            {
//                if (extractor == null)
//                {
//                    extractor = new AccessSchemaExtractor(this);
//                }
//                return extractor;
//            }
//        }

//        public override void ConfigureConnection(System.Data.IDbConnection connection)
//        {
//            //throw new Exception("The method or operation is not implemented.");
//        }

//        public override void TestConnection(System.Data.IDbConnection connection)
//        {
//            throw new Exception("The method or operation is not implemented.");
//        }
//    }
//}
