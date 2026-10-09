using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    public void Draw(SpriteBatch batch, Viewport viewport)
    {
        Current.Draw(batch, viewport);
        if (!IsTransitioning)
        {
            return;
        }

        batch.Begin(samplerState: SamplerState.PointClamp);
        batch.Draw(_fadePixel, new Rectangle(0, 0, viewport.Width, viewport.Height), Color.Black * FadeOpacity);
        batch.End();
    }
}
