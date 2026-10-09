using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes.Gameplay;

internal sealed partial class GameplayScene
{
    public override void Draw(SpriteBatch batch, Viewport viewport)
    {
        batch.GraphicsDevice.Clear(BackgroundColor);
        _camera.Update(Player.Motor.Position, 0, new Point(viewport.Width, viewport.Height));
        batch.Begin(blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, transformMatrix: _camera.View);
        _characterRenderer.Draw(batch, Player);
        batch.End();
    }
}
