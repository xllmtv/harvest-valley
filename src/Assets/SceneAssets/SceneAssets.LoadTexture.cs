using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Assets;

internal sealed partial class SceneAssets
{
    public Texture2D LoadTexture(string relativePath)
    {
        if (_textures.TryGetValue(relativePath, out var texture))
        {
            return texture;
        }

        string path = Path.Combine(AppContext.BaseDirectory, relativePath);
        using var stream = File.OpenRead(path);
        texture = Texture2D.FromStream(_graphics, stream);
        _textures.Add(relativePath, texture);
        return texture;
    }
}
