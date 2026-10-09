using System;
using HarvestValley.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.UI;

internal sealed partial class MainMenu
{
    private const int DiscordButtonIndex = 4;
    private const int SettingsButtonIndex = 5;
    private const string DiscordInviteUrl = "https://discord.gg/47arx2ZE6m";
    private static readonly Rectangle DiscordButtonSource = new(21, 13, 99, 34);
    private static readonly Vector2 ReferenceSize = new(1672, 941);
    private readonly Texture2D _logo;
    private readonly Texture2D[] _buttons;
    private readonly SpriteFont _footerFont;
    private readonly string _copyright = $"© {DateTime.Now.Year} Harvest Valley";
    private readonly string _version = $"v{GameVersion.Current}";
    private int _hoveredButton = -1;
    private int _pressedButton = -1;
}
