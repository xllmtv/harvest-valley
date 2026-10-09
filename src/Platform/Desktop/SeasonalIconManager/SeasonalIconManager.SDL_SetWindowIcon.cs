using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    [DllImport(SdlLibrary, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetWindowIcon(IntPtr window, IntPtr icon);
}
