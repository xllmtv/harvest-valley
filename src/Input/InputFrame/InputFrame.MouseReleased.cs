using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal readonly partial record struct InputFrame
{
    public bool MouseReleased => IsActive && Mouse.LeftButton == ButtonState.Released && PreviousMouse.LeftButton == ButtonState.Pressed;
}
