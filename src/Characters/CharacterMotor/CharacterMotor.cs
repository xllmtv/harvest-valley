using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal sealed partial class CharacterMotor
{
    public Vector2 Position { get; private set; }
    public Vector2 Velocity { get; private set; }
    public float Speed { get; }
}
