using Microsoft.Xna.Framework;

namespace HarvestValley.Rendering;

internal sealed partial class Camera2D
{
    public Matrix View => Matrix.CreateTranslation(-TopLeft.X, -TopLeft.Y, 0);
}
