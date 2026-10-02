using System;
using DiscordRPC;
using DiscordRPC.Logging;

namespace HarvestValley.Discord;

public sealed class DiscordPresence : IDisposable
{
    private const string ClientId = "1555644888153063494";

    private DiscordRpcClient? _client;

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

            _client.OnReady += (_, e) =>
            {
                Console.WriteLine(
                    $"[DISCORD] Connected as {e.User.Username}"
                );
            };

            _client.OnError += (_, e) =>
            {
                Console.WriteLine(
                    $"[DISCORD] Error: {e.Message}"
                );
            };

            _client.OnConnectionFailed += (_, _) =>
            {
                Console.WriteLine(
                    "[DISCORD] Connection failed."
                );
            };

            _client.Initialize();

            _client.SetPresence(
                new RichPresence
                {
                    Details = "☘ Work in progress",
                    State = "Growing something new",

                    Timestamps = new Timestamps(
                        DateTime.UtcNow
                    ),

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
                }
            );

            Console.WriteLine("[DISCORD] Presence active.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[DISCORD] Initialization failed: {ex.Message}"
            );
        }
    }

    public void Update(
        string details,
        string state
    )
    {
        if (
            _client is null ||
            !_client.IsInitialized
        )
        {
            return;
        }

        _client.UpdateDetails(details);
        _client.UpdateState(state);

        Console.WriteLine(
            $"[DISCORD] Updated: {details} | {state}"
        );
    }

    public void Dispose()
    {
        if (_client is null)
            return;

        Console.WriteLine("[DISCORD] Shutting down...");

        try
        {
            _client.ClearPresence();
            _client.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[DISCORD] Shutdown error: {ex.Message}"
            );
        }

        _client = null;
    }
}