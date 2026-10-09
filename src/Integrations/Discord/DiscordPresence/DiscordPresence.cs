using System;
using DiscordRPC;

namespace HarvestValley.Integrations.Discord;

public sealed partial class DiscordPresence : IDisposable
{
    private const string ClientId = "1555644888153063494";
    private DiscordRpcClient? _client;
}
