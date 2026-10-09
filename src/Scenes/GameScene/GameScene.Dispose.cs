namespace HarvestValley.Scenes;

internal abstract partial class GameScene
{
    public void Dispose() => Assets.Dispose();
}
