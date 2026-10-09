using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Characters;

internal sealed partial class MayaSprites
{
    public Texture2D GetFrame(CharacterAnimator animator) =>
        animator.IsWalking
            ? _walk[(int)animator.Facing, animator.FrameIndex]
            : _idle[(int)animator.Facing];
}
