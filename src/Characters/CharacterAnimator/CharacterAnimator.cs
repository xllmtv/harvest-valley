namespace HarvestValley.Characters;

internal sealed partial class CharacterAnimator
{
    private double _phase;
    public Direction8 Facing { get; private set; } = Direction8.South;
    public bool IsWalking { get; private set; }
    public int FrameCount { get; }
    public double FramesPerSecond { get; }
}
