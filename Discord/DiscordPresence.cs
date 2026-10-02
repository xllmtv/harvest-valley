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
                    $"Discord RPC connected: {e.User.Username}"
                );
            };

            _client.OnError += (_, e) =>
            {
                Console.WriteLine(
                    $"Discord RPC error: {e.Message}"
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
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Discord RPC initialization failed: {ex.Message}"
            );
        }
    }

    public void Update(
        string details,
        string state
    )
    {
        if (_client is null ||
            !_client.IsInitialized)
        {
            return;
        }

        _client.UpdateDetails(details);
        _client.UpdateState(state);
    }

    public void Dispose()
    {
        if (_client is null)
            return;

        try
        {
            _client.ClearPresence();
            _client.Dispose();
        }
        catch
        {
        }

        _client = null;
    }
}