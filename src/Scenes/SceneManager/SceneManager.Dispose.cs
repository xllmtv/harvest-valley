namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    public void Dispose()
    {
        Current.Dispose();
        _fadePixel.Dispose();
    }
}
