using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal sealed partial class MayaCharacter
{
    public void Update(Vector2 movement, double deltaSeconds, Rectangle movementBounds)
    {
        Vector2 displacement = Motor.Move(movement, deltaSeconds, movementBounds);
        Animator.Update(displacement, deltaSeconds);
    }
}
