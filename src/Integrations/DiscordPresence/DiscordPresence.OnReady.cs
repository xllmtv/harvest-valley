using System;
using DiscordRPC.Message;

namespace HarvestValley.Integrations;

public sealed partial class DiscordPresence
{
    private static void OnReady(object sender, ReadyMessage message)
    {
        Console.WriteLine($"[DISCORD] Connected as {message.User.Username}");
    }
}
