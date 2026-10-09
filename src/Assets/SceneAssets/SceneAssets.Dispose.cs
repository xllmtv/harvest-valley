namespace HarvestValley.Assets;

internal sealed partial class SceneAssets
{
    public void Dispose()
    {
        foreach (var texture in _textures.Values)
        {
            texture.Dispose();
        }

        _textures.Clear();
        _font?.Texture.Dispose();
        _font = null;
        _pixel?.Dispose();
        _pixel = null;
    }
}
