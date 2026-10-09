using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Platform.Desktop;

internal static partial class WindowManager
{
    [DllImport("SDL2.dll", EntryPoint = "SDL_MaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
    private static extern void MaximizeWindows(IntPtr window);
}
