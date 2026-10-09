using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal readonly partial record struct InputFrame(
    KeyboardState Keyboard,
    KeyboardState PreviousKeyboard,
    MouseState Mouse,
    MouseState PreviousMouse,
    GamePadState GamePad,
    GamePadState PreviousGamePad,
    bool IsActive)
{
}
