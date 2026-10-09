using System;

namespace HarvestValley.Integrations;

public sealed partial class DiscordPresence
{
    public void Dispose()
    {
        if (_client is null)
        {
            return;
        }

        Console.WriteLine("[DISCORD] Shutting down...");
        try
        {
            _client.ClearPresence();
            _client.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[DISCORD] Shutdown error: {ex.Message}");
        }

        _client = null;
    }
}
