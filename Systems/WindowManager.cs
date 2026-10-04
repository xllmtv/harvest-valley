using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Systems;

internal static class WindowManager
{
    public static void Maximize(IntPtr windowHandle)
    {
        if (OperatingSystem.IsWindows())
        {
            MaximizeWindows(windowHandle);
        }
        else if (OperatingSystem.IsMacOS())
        {
            MaximizeMacOS(windowHandle);
        }
        else if (OperatingSystem.IsLinux())
        {
            MaximizeLinux(windowHandle);
        }
    }

    [DllImport("SDL2.dll", EntryPoint = "SDL_MaximizeWindow",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void MaximizeWindows(IntPtr window);

    [DllImport("libSDL2-2.0.0.dylib", EntryPoint = "SDL_MaximizeWindow",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void MaximizeMacOS(IntPtr window);

    [DllImport("libSDL2-2.0.so.0", EntryPoint = "SDL_MaximizeWindow",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void MaximizeLinux(IntPtr window);
}
