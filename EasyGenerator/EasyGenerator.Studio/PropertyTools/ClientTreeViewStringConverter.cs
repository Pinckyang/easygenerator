﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.UI;

namespace EasyGenerator.Studio.PropertyTools
{
    public class ClientTreeViewStringConverter:StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            DBTreeView treeView = context.Instance as DBTreeView;
            //EntityInfo entity = treeView as EntityInfo;
            //if (entity != null)
            //{
            //    List<string> list = new List<string>();
            //    foreach (ColumnInfo column in entity.Columns)
            //    {
            //        list.Add(column.Name);
            //    }

            //    return new StandardValuesCollection(list.ToArray());
            //}
            return new StandardValuesCollection(new string[] { });
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
