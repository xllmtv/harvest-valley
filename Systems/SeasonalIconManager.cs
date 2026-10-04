using System;
using System.IO;
using System.Runtime.InteropServices;

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
    private const string IconPrefix = "HarvestValley";
    private const string SdlLibrary = "libSDL2-2.0.0.dylib";

    private static readonly string IconsDirectory = Path.Combine(
        AppContext.BaseDirectory,
        "Assets",
        "Icons"
    );

    private static IntPtr _windowHandle;
    private static int _lastMonth = -1;
    private static RealWorldSeason? _lastSeason;

    public static RealWorldSeason CurrentSeason =>
        GetSeason(DateTime.Now.Month);

    public static string CurrentSeasonName =>
        CurrentSeason.ToString();

    public static void Initialize(IntPtr windowHandle)
    {
        if (windowHandle == IntPtr.Zero)
        {
            throw new ArgumentException(
                "Window handle cannot be zero.",
                nameof(windowHandle)
            );
        }

        _windowHandle = windowHandle;
        _lastMonth = -1;
        _lastSeason = null;

        Refresh();
    }

    public static void Update()
    {
        int currentMonth = DateTime.Now.Month;

        if (currentMonth == _lastMonth)
        {
            return;
        }

        Refresh();
    }

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
            Console.WriteLine(
                $"[ICON] Missing seasonal icon: {iconPath}"
            );

            return;
        }

        if (TrySetWindowIcon(iconPath))
        {
            _lastSeason = season;

            Console.WriteLine(
                $"[ICON] Changed to {season} | {Path.GetFileName(iconPath)}"
            );
        }
    }

    public static RealWorldSeason GetSeason(int month)
    {
        return month switch
        {
            >= 3 and <= 5 => RealWorldSeason.Spring,
            >= 6 and <= 8 => RealWorldSeason.Summer,
            >= 9 and <= 11 => RealWorldSeason.Autumn,
            12 or 1 or 2 => RealWorldSeason.Winter,

            _ => throw new ArgumentOutOfRangeException(
                nameof(month),
                month,
                "Month must be between 1 and 12."
            )
        };
    }

    public static string GetBmpPath() =>
        GetIconPath(".bmp");

    public static string GetIcoPath() =>
        GetIconPath(".ico");

    public static string GetIcnsPath() =>
        GetIconPath(".icns");

    public static bool BmpExists() =>
        File.Exists(GetBmpPath());

    public static bool IcoExists() =>
        File.Exists(GetIcoPath());

    public static bool IcnsExists() =>
        File.Exists(GetIcnsPath());

    private static string GetIconPath(string extension)
    {
        return Path.Combine(
            IconsDirectory,
            $"{IconPrefix}-{CurrentSeason}{extension}"
        );
    }

    private static bool TrySetWindowIcon(string path)
    {
        try
        {
            IntPtr rw = SDL_RWFromFile(path, "rb");

            if (rw == IntPtr.Zero)
            {
                Console.WriteLine(
                    $"[ICON] SDL_RWFromFile failed: {GetSdlError()}"
                );

                return false;
            }

            IntPtr surface = SDL_LoadBMP_RW(rw, 1);

            if (surface == IntPtr.Zero)
            {
                Console.WriteLine(
                    $"[ICON] SDL_LoadBMP failed: {GetSdlError()}"
                );

                return false;
            }

            try
            {
                SDL_SetWindowIcon(_windowHandle, surface);
                return true;
            }
            finally
            {
                SDL_FreeSurface(surface);
            }
        }
        catch (DllNotFoundException ex)
        {
            Console.WriteLine(
                $"[ICON] SDL2 library not found: {ex.Message}"
            );

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[ICON] Failed to change icon: {ex.Message}"
            );

            return false;
        }
    }

    private static string GetSdlError()
    {
        IntPtr error = SDL_GetError();

        return error == IntPtr.Zero
            ? "Unknown SDL error."
            : Marshal.PtrToStringUTF8(error) ?? "Unknown SDL error.";
    }

    [DllImport(
        SdlLibrary,
        CallingConvention = CallingConvention.Cdecl
    )]
    private static extern IntPtr SDL_RWFromFile(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string file,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string mode
    );

    [DllImport(
        SdlLibrary,
        CallingConvention = CallingConvention.Cdecl
    )]
    private static extern IntPtr SDL_LoadBMP_RW(
        IntPtr src,
        int freeSrc
    );

    [DllImport(
        SdlLibrary,
        CallingConvention = CallingConvention.Cdecl
    )]
    private static extern void SDL_SetWindowIcon(
        IntPtr window,
        IntPtr icon
    );

    [DllImport(
        SdlLibrary,
        CallingConvention = CallingConvention.Cdecl
    )]
    private static extern void SDL_FreeSurface(
        IntPtr surface
    );

    [DllImport(
        SdlLibrary,
        CallingConvention = CallingConvention.Cdecl
    )]
    private static extern IntPtr SDL_GetError();
}