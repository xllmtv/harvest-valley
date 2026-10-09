using System;
using DiscordRPC.Message;

namespace HarvestValley.Integrations.Discord;

public sealed partial class DiscordPresence
{
    private static void OnConnectionFailed(object sender, ConnectionFailedMessage message)
    {
        Console.WriteLine("[DISCORD] Connection failed.");
    }
}
