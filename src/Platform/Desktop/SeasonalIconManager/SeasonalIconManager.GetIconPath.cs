using System.IO;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    private static string GetIconPath(string extension)
    {
        return Path.Combine(IconsDirectory, $"{IconPrefix}-{CurrentSeason}{extension}");
    }
}
