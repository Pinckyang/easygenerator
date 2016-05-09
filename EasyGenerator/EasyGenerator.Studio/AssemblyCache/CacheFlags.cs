using System;

namespace EasyGenerator.Studio.AssemblyCache
{
    [Flags]
    internal enum CacheFlags : uint
    {
        CACHE_ZAP = 1,
        CACHE_GAC = 2,
    }
}

