using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    [DllImport(SdlLibrary, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_RWFromFile([MarshalAs(UnmanagedType.LPUTF8Str)] string file, [MarshalAs(UnmanagedType.LPUTF8Str)] string mode);
}
