using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.PropertyTools
{
    public class ColumnsFromTableNameConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            LoginModule loginModule = context.Instance as LoginModule;
            string tableName=loginModule.TableName;

            ContextObject rootContextObject = loginModule.GetRoot();
            if (!(rootContextObject is Project))
            {
                return new StandardValuesCollection(new string[] { });
            }

            Project project = rootContextObject as Project;
            List<string> list = new List<string>();
            foreach (ColumnInfo column in project.Database.Tables.Find(e=>e.Name==tableName).Columns)
            {
                list.Add(column.Name);
            }

            return new StandardValuesCollection(list.ToArray());
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
