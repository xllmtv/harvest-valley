using System;
using HarvestValley.Platform.Desktop;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    private static void LogEnvironment()
    {
        Console.WriteLine($"[GAME] Starting | " + $"{DateTime.Now:MMMM} | " + $"{SeasonalIconManager.CurrentSeason}");
        Console.WriteLine(
            $"[ICON] BMP: {SeasonalIconManager.BmpExists()} | " +
            $"ICO: {SeasonalIconManager.IcoExists()} | " +
            $"ICNS: {SeasonalIconManager.IcnsExists()}");
    }
}
