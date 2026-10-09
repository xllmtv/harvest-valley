using System;
using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal sealed partial class CharacterAnimator
{
    public void Update(Vector2 displacement, double deltaSeconds)
    {
        if (!double.IsFinite(deltaSeconds) || deltaSeconds < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(deltaSeconds));
        }

        IsWalking = displacement.LengthSquared() > 0;
        if (!IsWalking)
        {
            _phase = 0;
            return;
        }

        Facing = Directions.FromMovement(displacement);
        _phase = (_phase + deltaSeconds * FramesPerSecond) % FrameCount;
    }
}
