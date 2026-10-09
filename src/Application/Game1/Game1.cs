using HarvestValley.Input;
using HarvestValley.Integrations.Discord;
using HarvestValley.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Application;

public sealed partial class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch = null!;
    private SceneManager _scenes = null!;
    private GameInput _input = null!;
    private bool _wasActive;
    private DiscordPresence? _discordPresence;
}
