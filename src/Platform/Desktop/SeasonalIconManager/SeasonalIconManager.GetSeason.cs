using System;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    public static RealWorldSeason GetSeason(int month)
    {
        return month switch
        {
            >= 3 and <= 5 => RealWorldSeason.Spring,
            >= 6 and <= 8 => RealWorldSeason.Summer,
            >= 9 and <= 11 => RealWorldSeason.Autumn,
            12 or 1 or 2 => RealWorldSeason.Winter,
            _ => throw new ArgumentOutOfRangeException(nameof(month), month, "Month must be between 1 and 12.")
        };
    }
}
