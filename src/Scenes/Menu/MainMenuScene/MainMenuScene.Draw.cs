using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes.Menu;

internal sealed partial class MainMenuScene
{
    public override void Draw(SpriteBatch batch, Viewport viewport)
    {
        float scale = Math.Max((float)viewport.Width / _wallpaper.Width, (float)viewport.Height / _wallpaper.Height);
        batch.Begin(samplerState: SamplerState.LinearClamp);
        batch.Draw(
            _wallpaper,
            new Vector2(viewport.Width / 2f, viewport.Height / 2f),
            null,
            Color.White,
            0,
            new Vector2(_wallpaper.Width / 2f, _wallpaper.Height / 2f),
            scale,
            SpriteEffects.None,
            0);
        batch.End();
        _menu.Draw(batch, viewport);
    }
}
