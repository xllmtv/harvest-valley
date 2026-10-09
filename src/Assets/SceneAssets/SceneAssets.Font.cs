using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Assets;

internal sealed partial class SceneAssets
{
    public SpriteFont Font => _font ??= PixelFont.Load(_graphics, Path.Combine(AppContext.BaseDirectory, "Assets", "Gui", "Fonts", "MenuPixel.json"));
}
