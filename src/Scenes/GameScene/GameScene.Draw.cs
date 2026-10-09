using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal abstract partial class GameScene
{
    public abstract void Draw(SpriteBatch batch, Viewport viewport);
}
