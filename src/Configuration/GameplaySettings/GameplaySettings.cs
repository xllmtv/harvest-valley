namespace HarvestValley.Configuration;

internal sealed partial class GameplaySettings
{
    public float MovementSpeed { get; init; } = 120;
    public double WalkFramesPerSecond { get; init; } = 8;
    public float CameraFollowSharpness { get; init; } = 12;
    public float CharacterScale { get; init; } = 1f;
}
