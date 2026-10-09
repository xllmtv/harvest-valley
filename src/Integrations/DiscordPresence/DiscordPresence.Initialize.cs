using System;
using DiscordRPC;
using DiscordRPC.Logging;

namespace HarvestValley.Integrations;

public sealed partial class DiscordPresence
{
    public void Initialize()
    {
        Console.WriteLine("[DISCORD] Initializing...");
        try
        {
            _client = new DiscordRpcClient(ClientId)
            {
                Logger = new ConsoleLogger
                {
                    Level = LogLevel.Warning
                }
            };
            _client.OnReady += OnReady;
            _client.OnError += OnError;
            _client.OnConnectionFailed += OnConnectionFailed;
            _client.Initialize();
            _client.SetPresence(new RichPresence
            {
                Details = "☘ Work in progress",
                State = "Growing something new",
                Timestamps = new Timestamps(DateTime.UtcNow),
                Buttons =
                [
                    new Button
                    {
                        Label = "Visit the Community",
                        Url = "https://discord.gg/47arx2ZE6m"
                    },
                    new Button
                    {
                        Label = "Explore the Project",
                        Url = "https://github.com/xllmtv/harvest-valley"
                    }
                ]
            });
            Console.WriteLine("[DISCORD] Presence active.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[DISCORD] Initialization failed: {ex.Message}");
        }
    }
}
