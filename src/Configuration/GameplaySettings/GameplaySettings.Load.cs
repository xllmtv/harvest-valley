using System.IO;
using System.Text.Json;

namespace HarvestValley.Configuration;

internal sealed partial class GameplaySettings
{
    public static GameplaySettings Load(string path)
    {
        var settings = JsonSerializer.Deserialize<GameplaySettings>(File.ReadAllText(path))
            ?? throw new InvalidDataException($"Empty gameplay settings: {path}");
        settings.Validate();
        return settings;
    }
}
