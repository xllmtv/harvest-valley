using System;
using Microsoft.Xna.Framework;

namespace HarvestValley.Rendering;

internal sealed partial class Camera2D
{
    public void Update(Vector2 target, double deltaSeconds, Point viewSize)
    {
        ViewSize = viewSize;
        float weight = (float)(1 - Math.Exp(-_sharpness * deltaSeconds));
        Position = Vector2.Lerp(Position, target, weight);
    }
}
