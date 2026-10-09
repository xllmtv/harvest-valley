using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal static partial class PlayerController
{
    public static Vector2 GetMovement(KeyboardState keyboard, bool isActive)
    {
        if (!isActive)
        {
            return Vector2.Zero;
        }

        var movement = new Vector2(
            (keyboard.IsKeyDown(Keys.D) ? 1 : 0) - (keyboard.IsKeyDown(Keys.A) ? 1 : 0),
            (keyboard.IsKeyDown(Keys.S) ? 1 : 0) - (keyboard.IsKeyDown(Keys.W) ? 1 : 0));
        if (movement.LengthSquared() > 1)
        {
            movement.Normalize();
        }

        return movement;
    }
}
