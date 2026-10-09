using System;
using HarvestValley.Scenes;
using HarvestValley.Scenes.Gameplay;
using HarvestValley.Scenes.Menu;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    private GameScene CreateScene(SceneKind kind) => kind switch
    {
        SceneKind.MainMenu => new MainMenuScene(GraphicsDevice),
        SceneKind.Gameplay => new GameplayScene(GraphicsDevice),
        _ => throw new ArgumentOutOfRangeException(nameof(kind))
    };
}
