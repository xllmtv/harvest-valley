using System;
using HarvestValley.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Rendering;

internal sealed partial class CharacterRenderer
{
    public void Draw(SpriteBatch batch, MayaCharacter character)
    {
        Vector2 feet = character.Motor.Position;
        feet = new Vector2(MathF.Round(feet.X), MathF.Round(feet.Y));
        batch.Draw(_sprites.GetFrame(character.Animator), feet, null, Color.White, 0, MayaSprites.FeetOrigin, _scale, SpriteEffects.None, 0);
    }
}
