using HarvestValley.Application;

namespace HarvestValley;

internal static class Program
{
    private static void Main()
    {
        using var game = new Game1();
        game.Run();
    }
}
