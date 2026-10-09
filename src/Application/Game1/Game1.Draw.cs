using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _scenes.Draw(_spriteBatch, GraphicsDevice.Viewport);
        base.Draw(gameTime);
    }
}
