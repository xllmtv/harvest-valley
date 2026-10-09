using System;
using DiscordRPC.Message;

namespace HarvestValley.Integrations.Discord;

public sealed partial class DiscordPresence
{
    private static void OnError(object sender, ErrorMessage message)
    {
        Console.WriteLine($"[DISCORD] Error: {message.Message}");
    }
}
