using System;
using System.IO;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    private const string IconPrefix = "HarvestValley";
    private const string SdlLibrary = "libSDL2-2.0.0.dylib";
    private static readonly string IconsDirectory = Path.Combine(AppContext.BaseDirectory, "Assets", "Icons");
    private static IntPtr _windowHandle;
    private static int _lastMonth = -1;
    private static RealWorldSeason? _lastSeason;
}
