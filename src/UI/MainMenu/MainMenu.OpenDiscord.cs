using System;
using System.ComponentModel;
using System.Diagnostics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private static void OpenDiscord()
    {
        try
        {
            using var process = Process.Start(new ProcessStartInfo(DiscordInviteUrl) { UseShellExecute = true });
        }
        catch (Exception ex) when (ex is Win32Exception or InvalidOperationException)
        {
            Console.WriteLine($"[MENU] Could not open Discord invite: {ex.Message}");
        }
    }
}
