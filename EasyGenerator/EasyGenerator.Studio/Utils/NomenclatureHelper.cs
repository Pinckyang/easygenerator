using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace EasyGenerator.Studio.Utils
{
    public class NomenclatureHelper
    {
        /// <summary>
        /// 转换为Pascal编码
        /// </summary>
        /// <param name="srcCase"></param>
        /// <returns></returns>
        public static string ConvertToPascalCase(string srcCase)
        {
            if (string.IsNullOrEmpty(srcCase))
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            string[] cases = srcCase.Split(' ', '_');
            if (cases.Length >1)
            {
                foreach (string item in cases)
                {
                    string result = ConvertToTitleCase(item);
                    builder.Append(result);
                }
            }
            else 
            {
                string result = ConvertToTitleCase(srcCase);
                builder.Append(result);
            }
            return builder.ToString();
        }

        public static string ConvertToTitleCase(string srcCase)
        {
            string textnoheader = srcCase.Remove(0,1);
            string header = srcCase.Substring(0, 1).ToUpper();
            string result = header + textnoheader;
            return result;
        }

        public static string ConvertToCamelCase(string srcCase)
        {
            if (string.IsNullOrEmpty(srcCase))
            {
                return string.Empty;
            }

            string text = ConvertToPascalCase(srcCase);
            string textnoheader=text.Remove(0,1);
            string header = text.Substring(0, 1).ToLower();
            return header + textnoheader;
        }
    }
}
