using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EasyGenerator.Studio.Utils
{
    public class XmlHelper
    {
        public static void ToXml<T>(string filePath, T sourceObj) where T : class
        {
            if (!string.IsNullOrWhiteSpace(filePath) && sourceObj != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    try
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(sourceObj.GetType());
                        xmlSerializer.Serialize(writer, sourceObj);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static T FromXml<T>(string filePath) where T:class
        {
            T result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    result = (T)xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}
