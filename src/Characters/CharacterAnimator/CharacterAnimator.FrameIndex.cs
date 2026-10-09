namespace HarvestValley.Characters;

internal sealed partial class CharacterAnimator
{
    public int FrameIndex => IsWalking ? (int)(_phase + 1e-9) % FrameCount : 0;
}
