using System;
using HarvestValley.Input;
using HarvestValley.Platform.Desktop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    protected override void Update(GameTime gameTime)
    {
        SeasonalIconManager.Update();
        InputFrame input = _input.Read(IsActive);
        double deltaSeconds = IsActive && _wasActive ? gameTime.ElapsedGameTime.TotalSeconds : 0;
        _wasActive = IsActive;
        if (_scenes.Update(deltaSeconds, input, GraphicsDevice.Viewport))
        {
            Console.WriteLine("[GAME] Exit requested.");
            Exit();
            return;
        }

        base.Update(gameTime);
    }
}
