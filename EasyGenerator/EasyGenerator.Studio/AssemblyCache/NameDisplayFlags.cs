namespace EasyGenerator.Studio.AssemblyCache
{
    using System;

    [Flags]
    internal enum NameDisplayFlags : uint
    {
        VERSION = 1,
        CULTURE = 2,
        KEY_TOKEN = 4,
        PUBLIC_KEY = 8,
    }
}

