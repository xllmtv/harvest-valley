using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    public SceneManager(GraphicsDevice graphics, Func<SceneKind, GameScene> createScene)
    {
        _createScene = createScene;
        Current = createScene(SceneKind.MainMenu);
        _fadePixel = new Texture2D(graphics, 1, 1);
        _fadePixel.SetData(new[] { Color.White });
    }
}
