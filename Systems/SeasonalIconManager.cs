using System;
using System.IO;

namespace HarvestValley.Systems;

public enum RealWorldSeason
{
    Spring,
    Summer,
    Autumn,
    Winter
}

public static class SeasonalIconManager
{
    public static RealWorldSeason GetCurrentSeason()
    {
        int month = DateTime.Now.Month;

        return month switch
        {
            3 or 4 or 5 => RealWorldSeason.Spring,
            6 or 7 or 8 => RealWorldSeason.Summer,
            9 or 10 or 11 => RealWorldSeason.Autumn,
            _ => RealWorldSeason.Winter
        };
    }

    public static string GetSeasonName()
    {
        return GetCurrentSeason().ToString();
    }

    public static string GetBmpPath()
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "Icons",
            $"HarvestValley-{GetSeasonName()}.bmp"
        );
    }

    public static string GetIcoPath()
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "Icons",
            $"HarvestValley-{GetSeasonName()}.ico"
        );
    }
}