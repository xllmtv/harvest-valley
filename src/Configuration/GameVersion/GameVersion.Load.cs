using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HarvestValley.Configuration;

internal static partial class GameVersion
{
    private static string Load()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "version.txt");
        try
        {
            string version = File.ReadAllText(path).Trim();
            if (version.Length <= 64 && Regex.IsMatch(version, @"\A[0-9]+\.[0-9]+\.[0-9]+(?:-[0-9A-Za-z.-]+)?(?:\+[0-9A-Za-z.-]+)?\z"))
            {
                return version;
            }

            Console.WriteLine("[VERSION] Invalid version.txt; expected a version such as 1.2.3.");
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            Console.WriteLine($"[VERSION] Cannot read version.txt: {ex.Message}");
        }

        return "unknown";
    }
}
