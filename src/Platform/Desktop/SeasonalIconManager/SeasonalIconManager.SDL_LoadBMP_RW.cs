using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    [DllImport(SdlLibrary, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_LoadBMP_RW(IntPtr src, int freeSrc);
}
