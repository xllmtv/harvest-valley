using System;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    public static RealWorldSeason CurrentSeason => GetSeason(DateTime.Now.Month);
}
