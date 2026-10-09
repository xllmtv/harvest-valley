using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private Rectangle GetButtonBounds(Viewport viewport, int index)
    {
        if (index == SettingsButtonIndex)
        {
            float settingsScale = Math.Max(0.75f, GetScale(viewport));
            int margin = (int)MathF.Round(Math.Max(20, 24 * GetScale(viewport)));
            int settingsWidth = (int)MathF.Round(64 * settingsScale);
            int settingsHeight = (int)MathF.Round(settingsWidth * (float)_buttons[index].Height / _buttons[index].Width);
            return new Rectangle(viewport.Width - margin - settingsWidth, margin, settingsWidth, settingsHeight);
        }

        if (index != DiscordButtonIndex)
        {
            return Transform(viewport, new Rectangle(707, 419 + index * 116, 258, 86));
        }

        float scale = Math.Max(0.75f, GetScale(viewport));
        Vector2 footerPosition = GetFooterPosition(viewport);
        int width = (int)MathF.Round(220 * scale);
        int height = (int)MathF.Round(width * (float)DiscordButtonSource.Height / DiscordButtonSource.Width);
        int gap = (int)MathF.Round(16 * scale);
        return new Rectangle((int)footerPosition.X, (int)footerPosition.Y - gap - height, width, height);
    }
}
