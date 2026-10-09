using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal readonly partial record struct InputFrame
{
    public bool MousePressed => IsActive && Mouse.LeftButton == ButtonState.Pressed && PreviousMouse.LeftButton == ButtonState.Released;
}
