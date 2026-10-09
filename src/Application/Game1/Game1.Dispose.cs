using System;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Console.WriteLine("[GAME] Shutting down...");
            _discordPresence?.Dispose();
            _discordPresence = null;
            _scenes?.Dispose();
            _spriteBatch?.Dispose();
        }

        base.Dispose(disposing);
    }
}
