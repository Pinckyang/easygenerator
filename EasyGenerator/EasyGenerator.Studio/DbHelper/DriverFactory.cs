using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper.MSSQL;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.DbHelper
{
    internal sealed class DriverFactory
    {
        internal static Driver GetDriver(string location)
        {
            ConnectionInfo connInfo = new ConnectionInfo(location);
            return GetDriver(connInfo);
        }

        internal static Driver GetDriver(ConnectionInfo connInfo)
        {
            switch (connInfo.Provider)
            {
                case "mssql":
                case "mssql2005":
                    return new MSSQLDriver(connInfo);
                case "mssql2008":
                    return new MSSQLDriver(connInfo);
                case "mssql2012":
                    return new MSSQLDriver(connInfo);
                //case "msaccess":
                //    return new AccessDriver(connInfo);
                default:
                    throw new Exception("Invalid Provider Type");
            }
        }

    }
}
