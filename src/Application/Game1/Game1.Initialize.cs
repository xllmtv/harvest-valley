using System;
using HarvestValley.Platform.Desktop;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    protected override void Initialize()
    {
        SeasonalIconManager.Initialize(Window.Handle);
        LogEnvironment();
        InitializeDiscord();
        base.Initialize();
        Console.WriteLine("[GAME] Ready.");
    }
}
