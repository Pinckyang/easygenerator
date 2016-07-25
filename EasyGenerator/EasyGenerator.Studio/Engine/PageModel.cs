using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.Engine
{
    public class PageModel:OutputFile
    {
        public static Dictionary<SqlType, string> TypeMapping = new Dictionary<SqlType, string>();
    }
}
