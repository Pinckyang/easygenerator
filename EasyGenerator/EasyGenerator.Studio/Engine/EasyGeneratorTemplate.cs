using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RazorEngine.Templating;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.Db;

namespace EasyGenerator.Studio.Engine
{
    public class EasyGeneratorTemplateBase<T> : TemplateBase<T>
    {
        public EasyGeneratorTemplateBase()
        {
        }
        public string GetTypeMapping(SqlType type)
        {
            string typeMappingValue = null;
            PageModel.TypeMapping.TryGetValue(type, out typeMappingValue);
            return (typeMappingValue == null) ? string.Empty : typeMappingValue;
        }
        public string Raw(string text)
        {
            return text;
        }
        public string ToUpperCase(string name)
        {
            return name.ToUpper();
        }
        public string ToLowerCase(string name)
        {
            return name.ToLower();
        }

        public Project GetProject(ContextObject contextObject)
        {
            return ((Project)contextObject.GetRoot());
        }

        /// <summary>
        /// 转换为Pascal命名方式
        /// </summary>
        /// <param name="srcCase"></param>
        /// <returns></returns>
        public string ConvertToPascalCase(string srcCase)
        {
            return NomenclatureHelper.ConvertToPascalCase(srcCase);
        }

        /// <summary>
        /// 转换为Camel命名方式
        /// </summary>
        /// <param name="srcCase"></param>
        /// <returns></returns>
        public string ConvertToCamelCase(string srcCase)
        {
            return NomenclatureHelper.ConvertToCamelCase(srcCase);
        }
    }
}
