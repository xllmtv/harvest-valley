using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Platform.Desktop;

internal static partial class WindowManager
{
    [DllImport("libSDL2-2.0.so.0", EntryPoint = "SDL_MaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
    private static extern void MaximizeLinux(IntPtr window);
}
