using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.PropertyTools
{
    public class StringValueDefaultConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            DBControl control = context.Instance as DBControl;
            ColumnInfo column = control.Owner as ColumnInfo;
            List<string> list = new List<string>();
            list.Add("DateTime.Now");
            list.Add("DateTime.Now.Date");
            list.Add("DateTime.Now.AddMonths(-1)");
            list.Add("DateTime.Now.AddDays(-1)");
            list.Add("DateTime.Now.AddHours(-1)");
            list.Add("DateTime.Now.AddMinutes(-1)");
            list.Add("DateTime.Now.Date.AddMonths(-1)");
            list.Add("DateTime.Now.Date.AddDays(-1)");
            list.Add("DateTime.Now.Date.AddHours(-1)");
            list.Add("DateTime.Now.Date.AddMinutes(-1)");
            list.Add("{IP}");

            if (!column.IsPrimaryKey && column.Referenced.Count>0)
            {
                foreach (ReferencedInfo kv in column.Referenced)
                {
                    list.Add("$"+kv.ReferencedTable.Name+"."+kv.ReferencedKey);
                }
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
