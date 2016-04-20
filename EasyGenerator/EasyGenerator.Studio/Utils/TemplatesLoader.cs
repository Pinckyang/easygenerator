/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.AssemblyCache;
using System.Reflection;
using System.CodeDom.Compiler;
//using EasyGenerator.Studio.Templates;
using System.Runtime.InteropServices;

namespace EasyGenerator.Studio.Utils
{
    public class TemplatesLoader 
    {
        private const string LONG_BASE_TYPE = "EasyGenerator.Template.TemplateBase";
        /*w/o namespaces*/
        private const string SHORT_BASE_TYPE = "TemplateBase"; 

        public TemplatesLoader()
        {
        }

        ~TemplatesLoader()
        {
            GC.SuppressFinalize(true);
        }


        //public void LoadTemplates(LibraryInfo libraryInfo)
        //{
        //    IAssemblyEnum assemblies;
        //    Assembly assembly = Assembly.Load(libraryInfo.AssemblyQualifiedName);
        //    foreach (Type type in assembly.GetTypes())
        //    {
        //        GC.Collect();
        //        if (type.IsClass)
        //        {
        //            OutputFile templateInfo = new OutputFile(libraryInfo.AssemblyName, type.Name, type.Namespace);
        //            if ((type.BaseType.ToString() == LONG_BASE_TYPE)
        //                || (type.BaseType.ToString() == SHORT_BASE_TYPE))
        //            {
        //                object instance = Activator.CreateInstance(type);
        //                templateInfo.Name = type.InvokeMember("Name", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null).ToString();
        //                templateInfo.Description = type.InvokeMember("Description", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null).ToString();
        //                templateInfo.RelativePath = type.InvokeMember("RelativePath", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null).ToString();
                        
        //                object members = type.InvokeMember("CreateOutputFile", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null);
        //                templateInfo.CreateFile = members.ToString() == "True";
        //                members = type.InvokeMember("IsProjectTemplate", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null);
        //                templateInfo.IsProjectTemplate = members.ToString() == "True";
        //                libraryInfo.Templates.Add(templateInfo);
        //            }
        //        }
        //    }
        //    IAssemblyName asmName = null;
        //    int i = Controllers.GetEnumerator(out assemblies, IntPtr.Zero, IntPtr.Zero, CacheFlags.CACHE_GAC, IntPtr.Zero);
        //    StringBuilder sbLibrary = new StringBuilder(0x100);
        //    do
        //    {
        //        i = assemblies.GetNextAssembly(IntPtr.Zero, out asmName, 0);
        //        if (i == 0)
        //        {
        //            uint capacity = (uint)sbLibrary.Capacity;
        //            asmName.GetName(ref capacity, sbLibrary);
        //            if (sbLibrary.ToString() == libraryInfo.AssemblyName)
        //            {
        //                Marshal.ReleaseComObject(asmName);
        //                return;
        //            }
        //        }
        //    }
        //    while (i == 0);
        //}

    }
}
