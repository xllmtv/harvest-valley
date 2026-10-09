using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Assets;

internal sealed partial class SceneAssets
{
    public Texture2D Pixel
    {
        get
        {
            if (_pixel is null)
            {
                _pixel = new Texture2D(_graphics, 1, 1);
                _pixel.SetData(new[] { Color.White });
            }

            return _pixel;
        }
    }
}
