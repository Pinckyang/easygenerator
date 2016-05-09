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

