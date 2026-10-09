using System;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal sealed partial class SceneManager : IDisposable
{
    public const double FadeDuration = 0.18;
    private readonly Func<SceneKind, GameScene> _createScene;
    private readonly Texture2D _fadePixel;
    private SceneKind? _destination;
    private bool _fadingOut;
    private double _elapsed;
    public GameScene Current { get; private set; }

    public event Action<SceneKind>? SceneChanged;
}
