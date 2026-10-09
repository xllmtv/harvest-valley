using HarvestValley.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes.Gameplay;

internal sealed partial class GameplayScene
{
    public override SceneAction Update(double deltaSeconds, InputFrame input, Viewport viewport)
    {
        if (input.BackPressed)
        {
            return SceneAction.MainMenu;
        }

        Player.Update(PlayerController.GetMovement(input.Keyboard, input.IsActive), deltaSeconds, MovementBounds);
        _camera.Update(Player.Motor.Position, deltaSeconds, new Point(viewport.Width, viewport.Height));
        return SceneAction.None;
    }
}
