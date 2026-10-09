using System;
using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal sealed partial class CharacterMotor
{
    public CharacterMotor(Vector2 position, float speed)
    {
        if (!float.IsFinite(speed) || speed <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speed));
        }

        Position = position;
        Speed = speed;
    }
}
