using System;
using HarvestValley.Input;
using HarvestValley.Scenes;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Application;

public sealed partial class Game1
{
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _input = new GameInput();
        _scenes = new SceneManager(GraphicsDevice, CreateScene);
        _scenes.SceneChanged += OnSceneChanged;
        Console.WriteLine("[GAME] Content loaded.");
    }
}
