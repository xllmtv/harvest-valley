using System;
using Microsoft.Xna.Framework;

namespace HarvestValley.Rendering;

internal sealed partial class Camera2D
{
    public Vector2 TopLeft => new(MathF.Round(Position.X - ViewSize.X / 2f), MathF.Round(Position.Y - ViewSize.Y / 2f));
}
