using System;

namespace HarvestValley.Characters;

internal sealed partial class CharacterAnimator
{
    public CharacterAnimator(int frameCount, double framesPerSecond)
    {
        if (frameCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(frameCount));
        }

        if (!double.IsFinite(framesPerSecond) || framesPerSecond <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(framesPerSecond));
        }

        FrameCount = frameCount;
        FramesPerSecond = framesPerSecond;
    }
}
