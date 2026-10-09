using HarvestValley.Input;
using HarvestValley.Scenes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    public SceneAction Update(Viewport viewport, InputFrame input)
    {
        MouseState mouse = input.Mouse;
        _hoveredButton = -1;
        if (input.IsActive)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (GetButtonBounds(viewport, i).Contains(mouse.Position))
                {
                    _hoveredButton = i;
                }
            }
        }
        else
        {
            _pressedButton = -1;
        }

        if (input.MousePressed)
        {
            _pressedButton = _hoveredButton;
        }

        SceneAction action = SceneAction.None;
        if (input.MouseReleased)
        {
            if (_pressedButton == _hoveredButton)
            {
                action = _pressedButton switch
                {
                    0 => SceneAction.Play,
                    3 => SceneAction.Exit,
                    _ => SceneAction.None
                };
            }

            if (_pressedButton == DiscordButtonIndex && _hoveredButton == DiscordButtonIndex)
            {
                OpenDiscord();
            }

            _pressedButton = -1;
        }

        return action;
    }
}
