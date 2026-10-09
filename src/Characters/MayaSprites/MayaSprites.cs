using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Characters;

internal sealed partial class MayaSprites
{
    public const int WalkFrameCount = 3;
    public const int SpriteSize = 48;
    public static readonly Vector2 FeetOrigin = new(SpriteSize / 2, SpriteSize);
    private readonly Texture2D[] _idle = new Texture2D[8];
    private readonly Texture2D[,] _walk = new Texture2D[8, WalkFrameCount];
}
