using System;
using HarvestValley.Configuration;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    private static void LogStartupHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("""
        
        ██╗  ██╗ █████╗ ██████╗ ██╗   ██╗███████╗███████╗████████╗
        ██║  ██║██╔══██╗██╔══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
        ███████║███████║██████╔╝██║   ██║█████╗  ███████╗   ██║
        ██╔══██║██╔══██║██╔══██╗╚██╗ ██╔╝██╔══╝  ╚════██║   ██║
        ██║  ██║██║  ██║██║  ██║ ╚████╔╝ ███████╗███████║   ██║
        ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝  ╚═══╝  ╚══════╝╚══════╝   ╚═╝

                        🌾  V A L L E Y  🌾
        
        """);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("              Growing something new.");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"                   Version {GameVersion.Current}");
        Console.WriteLine();
        Console.ResetColor();
    }
}
