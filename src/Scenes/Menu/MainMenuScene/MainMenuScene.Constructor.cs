using HarvestValley.UI;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes.Menu;

internal sealed partial class MainMenuScene
{
    public MainMenuScene(GraphicsDevice graphics) : base(graphics)
    {
        try
        {
            _wallpaper = Assets.LoadTexture("Assets/Background/wallpaper.png");
            _menu = new MainMenu(Assets);
        }
        catch
        {
            Assets.Dispose();
            throw;
        }
    }
}
