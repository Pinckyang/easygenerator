namespace EasyGenerator.Studio.AssemblyCache
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    [ComImport, Guid("CD193BC0-B4BC-11d2-9833-00C04FC31D2E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAssemblyName
    {
        void SetProperty_StubOnly_InvalidArgList_Do_Not_Call();
        void GetProperty_StubOnly_InvalidArgList_Do_Not_Call();
        void Finalize();
        void GetDisplayName(StringBuilder displayName, ref uint cch, NameDisplayFlags flags);
        void BindToObject_StubOnly_InvalidArgList_Do_Not_Call();
        void GetName(ref uint cch, StringBuilder name);
        void GetVersion(out uint versionHi, out uint versionLow);
        void IsEqual(IAssemblyName pName, uint cmpFlags);
        IAssemblyName Clone();
    }
}

