using System;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    public static void Initialize(IntPtr windowHandle)
    {
        if (windowHandle == IntPtr.Zero)
        {
            throw new ArgumentException("Window handle cannot be zero.", nameof(windowHandle));
        }

        _windowHandle = windowHandle;
        _lastMonth = -1;
        _lastSeason = null;
        Refresh();
    }
}
