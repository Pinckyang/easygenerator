﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.DB
{
    public enum DatabaseType
    {
        [XmlEnum(Name = "SQLServer2000")]
        SQLServer2000,

        [XmlEnum(Name = "SQLServer2005")]
        SQLServer2005,

        [XmlEnum(Name = "SQLServer2008")]
        SQLServer2008,

        [XmlEnum(Name = "SQLServer2012")]
        SQLServer2012,

        [XmlEnum(Name = "MySQL")]
        MySQL,

        [XmlEnum(Name = "Oracle")]
        Oracle
    }
}
