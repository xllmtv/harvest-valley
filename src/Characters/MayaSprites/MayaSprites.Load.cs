using System.IO;
using HarvestValley.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Characters;

internal sealed partial class MayaSprites
{
    private static Texture2D Load(SceneAssets assets, string path)
    {
        var texture = assets.LoadTexture($"Assets/Characters/Player/Maya/{path}");
        if (texture.Width != SpriteSize || texture.Height != SpriteSize)
        {
            throw new InvalidDataException($"Maya sprite must retain its 48x48 canvas: {path}");
        }

        return texture;
    }
}
