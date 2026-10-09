namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    public bool IsTransitioning => _destination.HasValue;
}
