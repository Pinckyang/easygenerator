using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace EasyGenerator.Studio.PropertyTools
{
    public class DateTimeDefaultConverter : StringConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
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
