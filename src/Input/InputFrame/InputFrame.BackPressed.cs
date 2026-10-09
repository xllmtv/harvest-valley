using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal readonly partial record struct InputFrame
{
    public bool BackPressed =>
        Pressed(Keys.Escape) ||
        (IsActive &&
         GamePad.Buttons.Back == ButtonState.Pressed &&
         PreviousGamePad.Buttons.Back == ButtonState.Released);
}
