using Microsoft.Xna.Framework;

namespace HarvestValley.Rendering;

internal sealed partial class Camera2D
{
    public Rectangle VisibleBounds => new((int)TopLeft.X, (int)TopLeft.Y, ViewSize.X, ViewSize.Y);
}
