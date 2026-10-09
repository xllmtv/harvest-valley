using System;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    private static bool TrySetWindowIcon(string path)
    {
        try
        {
            IntPtr rw = SDL_RWFromFile(path, "rb");
            if (rw == IntPtr.Zero)
            {
                Console.WriteLine($"[ICON] SDL_RWFromFile failed: {GetSdlError()}");
                return false;
            }

            IntPtr surface = SDL_LoadBMP_RW(rw, 1);
            if (surface == IntPtr.Zero)
            {
                Console.WriteLine($"[ICON] SDL_LoadBMP failed: {GetSdlError()}");
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
            Console.WriteLine($"[ICON] SDL2 library not found: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ICON] Failed to change icon: {ex.Message}");
            return false;
        }
    }
}
