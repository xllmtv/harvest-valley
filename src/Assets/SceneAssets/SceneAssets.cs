using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Assets;

internal sealed partial class SceneAssets : IDisposable
{
    private readonly GraphicsDevice _graphics;
    private readonly Dictionary<string, Texture2D> _textures = new(StringComparer.Ordinal);
    private SpriteFont? _font;
    private Texture2D? _pixel;
}
