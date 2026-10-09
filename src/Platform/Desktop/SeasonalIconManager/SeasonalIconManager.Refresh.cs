using System;
using System.IO;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    public static void Refresh()
    {
        if (_windowHandle == IntPtr.Zero)
        {
            return;
        }

        int month = DateTime.Now.Month;
        RealWorldSeason season = GetSeason(month);
        _lastMonth = month;
        if (_lastSeason == season)
        {
            return;
        }

        string iconPath = GetBmpPath();
        if (!File.Exists(iconPath))
        {
            Console.WriteLine($"[ICON] Missing seasonal icon: {iconPath}");
            return;
        }

        if (TrySetWindowIcon(iconPath))
        {
            _lastSeason = season;
            Console.WriteLine($"[ICON] Changed to {season} | {Path.GetFileName(iconPath)}");
        }
    }
}
