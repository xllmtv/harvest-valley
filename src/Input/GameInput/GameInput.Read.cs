using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Input;

internal sealed partial class GameInput
{
    public InputFrame Read(bool isActive)
    {
        var keyboard = Keyboard.GetState();
        var mouse = Mouse.GetState();
        var gamePad = GamePad.GetState(PlayerIndex.One);
        var frame = new InputFrame(
            keyboard,
            _wasActive ? _keyboard : keyboard,
            mouse,
            _wasActive ? _mouse : mouse,
            gamePad,
            _wasActive ? _gamePad : gamePad,
            isActive);
        _keyboard = keyboard;
        _mouse = mouse;
        _gamePad = gamePad;
        _wasActive = isActive;
        return frame;
    }
}
