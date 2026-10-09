using HarvestValley.Configuration;
using Microsoft.Xna.Framework;

namespace HarvestValley.Characters;

internal sealed partial class MayaCharacter
{
    public MayaCharacter(Vector2 spawn, GameplaySettings settings)
    {
        Motor = new CharacterMotor(spawn, settings.MovementSpeed);
        Animator = new CharacterAnimator(MayaSprites.WalkFrameCount, settings.WalkFramesPerSecond);
    }
}
