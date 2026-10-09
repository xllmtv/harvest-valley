using HarvestValley.Integrations;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    private void InitializeDiscord()
    {
        _discordPresence = new DiscordPresence();
        _discordPresence.Initialize();
    }
}
