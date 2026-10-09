using System.IO;
using HarvestValley.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private static Texture2D LoadTexture(SceneAssets assets, string filename) => assets.LoadTexture(Path.Combine("Assets", "Gui", "MainMenu", filename));
}
