using System.IO;

namespace HarvestValley.Configuration;

internal sealed partial class GameplaySettings
{
    public void Validate()
    {
        if (!float.IsFinite(MovementSpeed) || MovementSpeed <= 0 ||
            !double.IsFinite(WalkFramesPerSecond) || WalkFramesPerSecond <= 0 ||
            !float.IsFinite(CameraFollowSharpness) || CameraFollowSharpness <= 0 ||
            !float.IsFinite(CharacterScale) || CharacterScale <= 0)
        {
            throw new InvalidDataException("Movement speed, animation FPS, camera sharpness and character scale must be finite and positive.");
        }
    }
}
