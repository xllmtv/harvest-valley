using System;

namespace HarvestValley.Integrations.Discord;

public sealed partial class DiscordPresence
{
    public void Update(string details, string state)
    {
        if (_client is null || !_client.IsInitialized)
        {
            return;
        }

        _client.UpdateDetails(details);
        _client.UpdateState(state);
        Console.WriteLine($"[DISCORD] Updated: {details} | {state}");
    }
}
