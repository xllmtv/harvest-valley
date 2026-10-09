using Microsoft.Xna.Framework;

namespace HarvestValley.Rendering;

internal sealed partial class Camera2D
{
    public Vector2 Position { get; private set; }
    public Point ViewSize { get; private set; }

    private readonly float _sharpness;
}
