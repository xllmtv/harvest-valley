using System;

namespace HarvestValley.Platform.Desktop;

internal static partial class WindowManager
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
}
