using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal static partial class Directions
{
    public static Direction8 FromMovement(Vector2 movement) => (movement.X, movement.Y) switch
    {
        ( > 0, < 0) => Direction8.NorthEast,
        ( > 0, > 0) => Direction8.SouthEast,
        ( < 0, > 0) => Direction8.SouthWest,
        ( < 0, < 0) => Direction8.NorthWest,
        ( > 0, _) => Direction8.East,
        ( < 0, _) => Direction8.West,
        (_, < 0) => Direction8.North,
        _ => Direction8.South
    };
}
