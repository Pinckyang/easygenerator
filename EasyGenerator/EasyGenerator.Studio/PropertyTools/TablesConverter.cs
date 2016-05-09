using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.PropertyTools
{
    public class TablesConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ContextObject contextObject = context.Instance as ContextObject;
            ContextObject rootContextObject = contextObject.GetRoot();
            if (!(rootContextObject is Project))
            {
                return new StandardValuesCollection(new string[] { });
            }

            Project project = rootContextObject as Project;
            List<string> list = new List<string>();
            foreach (EntityInfo entity in project.Database.Tables)
            {
                list.Add(entity.Name);
            }

            return  new StandardValuesCollection(list.ToArray());
        }

        /// <summary>
        /// 下拉列表中没有包含的值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
            // return true;
        }  
    }
}
