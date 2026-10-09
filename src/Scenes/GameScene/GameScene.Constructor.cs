using HarvestValley.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal abstract partial class GameScene
{
    protected GameScene(GraphicsDevice graphics) => Assets = new SceneAssets(graphics);
}
