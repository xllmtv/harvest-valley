using Microsoft.Xna.Framework;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            IsFullScreen = false
        };
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        IsFixedTimeStep = false;
        Window.Title = "Harvest Valley";
        Window.AllowUserResizing = true;
        Window.IsBorderless = false;
        LogStartupHeader();
    }
}
