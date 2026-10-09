using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal sealed partial class GameInput
{
    private KeyboardState _keyboard = Keyboard.GetState();
    private MouseState _mouse = Mouse.GetState();
    private GamePadState _gamePad = GamePad.GetState(PlayerIndex.One);
    private bool _wasActive;
}
