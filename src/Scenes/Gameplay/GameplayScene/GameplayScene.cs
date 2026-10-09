using HarvestValley.Characters;
using HarvestValley.Rendering;
using Microsoft.Xna.Framework;

namespace HarvestValley.Scenes.Gameplay;

internal sealed partial class GameplayScene : GameScene
{
    private static readonly Color BackgroundColor = new(96, 138, 66);
    private static readonly Rectangle MovementBounds = new(-2024, -1488, 4048, 3000);
    private readonly Camera2D _camera;
    private readonly CharacterRenderer _characterRenderer;
    public MayaCharacter Player { get; }
}
