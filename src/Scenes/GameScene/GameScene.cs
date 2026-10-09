using System;
using HarvestValley.Assets;

namespace HarvestValley.Scenes;

internal abstract partial class GameScene : IDisposable
{
    protected SceneAssets Assets { get; }
    public abstract SceneKind Kind { get; }
}
