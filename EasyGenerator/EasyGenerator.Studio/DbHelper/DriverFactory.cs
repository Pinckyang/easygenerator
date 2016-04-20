using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper.MSSQL;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.DbHelper
{
    internal sealed class DriverFactory
    {
        internal static Driver GetDriver(string location, Project project)
        {
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo(location);
                return GetDriver(connInfo, project);
            }
            catch 
            {
                throw;
            }
        }

        internal static Driver GetDriver(ConnectionInfo connInfo,Project project)
        {
            switch (connInfo.Provider)
            {
                case "mssql":
                case "mssql2005":
                    return new MSSQLDriver(connInfo, project);
                case "mssql2008":
                    return new MSSQLDriver(connInfo, project);
                //case "msaccess":
                //    return new AccessDriver(connInfo);
                default:
                    throw new Exception("Invalid Provider Type");
            }
        }

    }
}
