using System;
using System.IO;
using HarvestValley.Characters;
using HarvestValley.Configuration;
using HarvestValley.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes.Gameplay;

internal sealed partial class GameplayScene
{
    public GameplayScene(GraphicsDevice graphics) : base(graphics)
    {
        try
        {
            var settings = GameplaySettings.Load(Path.Combine(AppContext.BaseDirectory, "Config", "gameplay.json"));
            Player = new MayaCharacter(Vector2.Zero, settings);
            _characterRenderer = new CharacterRenderer(new MayaSprites(Assets), settings.CharacterScale);
            _camera = new Camera2D(settings.CameraFollowSharpness);
            _camera.SnapTo(Player.Motor.Position, new Point(graphics.Viewport.Width, graphics.Viewport.Height));
        }
        catch
        {
            Assets.Dispose();
            throw;
        }
    }
}
