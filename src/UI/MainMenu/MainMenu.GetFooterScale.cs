using System;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private float GetFooterScale(Viewport viewport) => Math.Max(2, (int)MathF.Round(3 * GetScale(viewport))) - 4f / _footerFont.LineSpacing;
}
