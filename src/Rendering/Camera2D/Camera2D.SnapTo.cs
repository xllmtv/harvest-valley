using Microsoft.Xna.Framework;

namespace HarvestValley.Rendering;

internal sealed partial class Camera2D
{
    public void SnapTo(Vector2 target, Point viewSize)
    {
        Position = target;
        ViewSize = viewSize;
    }
}
