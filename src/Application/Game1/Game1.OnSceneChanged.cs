using HarvestValley.Scenes;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    private void OnSceneChanged(SceneKind kind)
    {
        _discordPresence?.Update(
            kind == SceneKind.Gameplay ? "Exploring the valley" : "In the main menu",
            kind == SceneKind.Gameplay ? "Playing as Maya" : "Growing something new");
    }
}
