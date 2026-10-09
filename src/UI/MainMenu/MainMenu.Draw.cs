using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    public void Draw(SpriteBatch spriteBatch, Viewport viewport)
    {
        float scale = GetScale(viewport);
        spriteBatch.Begin(blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp);
        spriteBatch.Draw(_logo, Transform(viewport, new Rectangle(536, 96, 600, 288)), new Rectangle(12, 24, 416, 200), Color.White);
        for (int i = 0; i < _buttons.Length; i++)
        {
            Rectangle bounds = GetButtonBounds(viewport, i);
            Color tint = Color.White;
            if (_hoveredButton == i)
            {
                tint = new Color(255, 240, 205);
                if (_pressedButton == i)
                {
                    bounds.Y += Math.Max(1, (int)MathF.Round(3 * scale));
                }
                else
                {
                    bounds.Y -= Math.Max(1, (int)MathF.Round(2 * scale));
                }
            }

            Rectangle? source = i == DiscordButtonIndex ? DiscordButtonSource : null;
            spriteBatch.Draw(_buttons[i], bounds, source, tint);
        }

        spriteBatch.End();
        float fontScale = GetFooterScale(viewport);
        Vector2 footerPosition = GetFooterPosition(viewport);
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        DrawFooter(spriteBatch, _copyright, footerPosition, fontScale);
        DrawFooter(
            spriteBatch,
            _version,
            new Vector2(
                viewport.Width - footerPosition.X - _footerFont.MeasureString(_version).X * fontScale,
                footerPosition.Y),
            fontScale);
        spriteBatch.End();
    }
}
