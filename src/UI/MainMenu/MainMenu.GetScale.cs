using System;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private static float GetScale(Viewport viewport) => Math.Min(viewport.Width / ReferenceSize.X, viewport.Height / ReferenceSize.Y);
}
