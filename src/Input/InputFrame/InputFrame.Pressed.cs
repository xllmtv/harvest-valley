using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal readonly partial record struct InputFrame
{
    public bool Pressed(Keys key) => IsActive && Keyboard.IsKeyDown(key) && PreviousKeyboard.IsKeyUp(key);
}
