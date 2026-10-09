using System;
using HarvestValley.Assets;

namespace HarvestValley.Characters;

internal sealed partial class MayaSprites
{
    public MayaSprites(SceneAssets assets)
    {
        foreach (Direction8 direction in Enum.GetValues<Direction8>())
        {
            _idle[(int)direction] = Load(assets, $"Idle/{direction.AssetFolder()}/idle.png");
            for (int frame = 0; frame < WalkFrameCount; frame++)
            {
                _walk[(int)direction, frame] = Load(assets, $"Walk/{direction.AssetFolder()}/walk-{frame + 1}.png");
            }
        }
    }
}
