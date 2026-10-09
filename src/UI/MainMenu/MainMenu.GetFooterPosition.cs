using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private Vector2 GetFooterPosition(Viewport viewport)
    {
        float scale = GetScale(viewport);
        float marginX = MathF.Round(Math.Max(20, 24 * scale));
        float marginY = MathF.Round(Math.Max(16, 16 * scale));
        float textHeight = _footerFont.MeasureString(_copyright).Y * GetFooterScale(viewport);
        return new Vector2(marginX, viewport.Height - marginY - textHeight);
    }
}
