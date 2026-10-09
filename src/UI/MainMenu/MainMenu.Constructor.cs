using HarvestValley.Assets;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    public MainMenu(SceneAssets assets)
    {
        _logo = LoadTexture(assets, "mainmenu-logo.png");
        _buttons =
        [
            LoadTexture(assets, "button-play.png"),
            LoadTexture(assets, "button-load.png"),
            LoadTexture(assets, "button-coop.png"),
            LoadTexture(assets, "button-exit.png"),
            LoadTexture(assets, "button-discord.png"),
            LoadTexture(assets, "button-settings.png")
        ];
        _footerFont = assets.Font;
    }
}
