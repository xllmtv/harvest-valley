using System;
using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal sealed partial class CharacterMotor
{
    public Vector2 Move(Vector2 intent, double deltaSeconds, Rectangle bounds)
    {
        if (!double.IsFinite(deltaSeconds) || deltaSeconds < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(deltaSeconds));
        }

        if (intent.LengthSquared() > 1)
        {
            intent.Normalize();
        }

        Vector2 previous = Position;
        Position = Vector2.Clamp(
            Position + intent * (float)(Speed * deltaSeconds),
            new Vector2(bounds.Left, bounds.Top),
            new Vector2(bounds.Right, bounds.Bottom));
        Vector2 displacement = Position - previous;
        Velocity = deltaSeconds > 0 ? displacement / (float)deltaSeconds : Vector2.Zero;
        return displacement;
    }
}
