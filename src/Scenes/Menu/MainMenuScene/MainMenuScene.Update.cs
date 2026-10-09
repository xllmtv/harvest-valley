using HarvestValley.Input;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes.Menu;

internal sealed partial class MainMenuScene
{
    public override SceneAction Update(double deltaSeconds, InputFrame input, Viewport viewport) =>
        input.BackPressed ? SceneAction.Exit : _menu.Update(viewport, input);
}
