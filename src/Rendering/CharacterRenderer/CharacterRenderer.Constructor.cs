using HarvestValley.Characters;

namespace HarvestValley.Rendering;

internal sealed partial class CharacterRenderer
{
    public CharacterRenderer(MayaSprites sprites, float scale)
    {
        _sprites = sprites;
        _scale = scale;
    }
}
