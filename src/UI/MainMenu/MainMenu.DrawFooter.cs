using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private void DrawFooter(SpriteBatch spriteBatch, string text, Vector2 position, float scale)
    {
        position = new Vector2(MathF.Round(position.X), MathF.Round(position.Y));
        float shadowOffset = MathF.Round(scale);
        spriteBatch.DrawString(_footerFont, text, position + new Vector2(shadowOffset), Color.Black * 0.85f, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        spriteBatch.DrawString(_footerFont, text, position, new Color(255, 250, 235), 0, Vector2.Zero, scale, SpriteEffects.None, 0);
    }
}
