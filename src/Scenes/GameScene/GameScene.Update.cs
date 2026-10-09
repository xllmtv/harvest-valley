using HarvestValley.Input;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal abstract partial class GameScene
{
    public abstract SceneAction Update(double deltaSeconds, InputFrame input, Viewport viewport);
}
