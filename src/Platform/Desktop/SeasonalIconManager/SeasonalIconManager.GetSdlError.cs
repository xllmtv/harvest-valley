using System;
using System.Runtime.InteropServices;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    private static string GetSdlError()
    {
        IntPtr error = SDL_GetError();
        return error == IntPtr.Zero ? "Unknown SDL error." : Marshal.PtrToStringUTF8(error) ?? "Unknown SDL error.";
    }
}
