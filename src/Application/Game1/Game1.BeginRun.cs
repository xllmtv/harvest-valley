using HarvestValley.Platform.Desktop;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    protected override void BeginRun()
    {
        base.BeginRun();
        WindowManager.Maximize(Window.Handle);
    }
}
