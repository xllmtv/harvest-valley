using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private static Rectangle Transform(Viewport viewport, Rectangle bounds)
    {
        float scale = GetScale(viewport);
        Vector2 offset = (new Vector2(viewport.Width, viewport.Height) - ReferenceSize * scale) / 2;
        return new Rectangle(
            (int)MathF.Round(offset.X + bounds.X * scale),
            (int)MathF.Round(offset.Y + bounds.Y * scale),
            (int)MathF.Round(bounds.Width * scale),
            (int)MathF.Round(bounds.Height * scale));
    }
}
