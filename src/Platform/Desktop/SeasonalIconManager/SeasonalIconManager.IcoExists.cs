using System.IO;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    public static bool IcoExists() => File.Exists(GetIcoPath());
}
