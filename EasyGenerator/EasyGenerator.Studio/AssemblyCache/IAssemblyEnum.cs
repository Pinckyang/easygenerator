/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

namespace EasyGenerator.Studio.AssemblyCache
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("21b8916c-f28e-11d2-a473-00c04f8ef448"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAssemblyEnum
    {
        [PreserveSig]
        int GetNextAssembly(IntPtr reservedPassZero, out IAssemblyName asmName, uint flagsPassZero);
        void Reset();
        IAssemblyEnum Clone();
    }
}

