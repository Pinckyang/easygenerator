namespace EasyGenerator.Studio.AssemblyCache
{
    using System;
    using System.Runtime.InteropServices;

    internal class Controllers
    {
        [DllImport("Fusion.dll", EntryPoint="CreateAssemblyEnum", CharSet=CharSet.Auto)]
        public static extern int GetEnumerator(out IAssemblyEnum ppAsmCache, IntPtr pAppCtx, IntPtr pName, CacheFlags dwFlags, IntPtr pvReserved);
    }
}

