using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HarvestValley.Discord;
using HarvestValley.Systems;

namespace HarvestValley;

public sealed class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;

    private SpriteBatch _spriteBatch = null!;
    private Texture2D _wallpaper = null!;
    private MainMenu _mainMenu = null!;
    private DiscordPresence? _discordPresence;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            IsFullScreen = false
        };
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Title = "Harvest Valley";
        Window.AllowUserResizing = true;
        Window.IsBorderless = false;
        LogStartupHeader();
    }

    protected override void Initialize()
    {
        SeasonalIconManager.Initialize(Window.Handle);
        LogEnvironment();
        InitializeDiscord();
        base.Initialize();
        Console.WriteLine("[GAME] Ready.");
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        string wallpaperPath = Path.Combine(
            AppContext.BaseDirectory, "Assets", "Background", "wallpaper.png"
        );
        using var wallpaperStream = File.OpenRead(wallpaperPath);
        _wallpaper = Texture2D.FromStream(GraphicsDevice, wallpaperStream);
        _mainMenu = new MainMenu(GraphicsDevice);
        Console.WriteLine("[GAME] Content loaded.");
    }

    protected override void BeginRun()
    {
        base.BeginRun();
        WindowManager.Maximize(Window.Handle);
    }

    protected override void Update(GameTime gameTime)
    {
        SeasonalIconManager.Update();

        if (_mainMenu.Update(GraphicsDevice.Viewport, IsActive) || ShouldExit())
        {
            Console.WriteLine("[GAME] Exit requested.");
            Exit();
            return;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        Viewport viewport = GraphicsDevice.Viewport;
        float scale = Math.Max(
            (float)viewport.Width / _wallpaper.Width,
            (float)viewport.Height / _wallpaper.Height
        );
        var center = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
        var origin = new Vector2(_wallpaper.Width / 2f, _wallpaper.Height / 2f);

        _spriteBatch.Begin(samplerState: SamplerState.LinearClamp);
        _spriteBatch.Draw(
            _wallpaper, center, null, Color.White, 0f, origin,
            scale, SpriteEffects.None, 0f
        );
        _spriteBatch.End();
        _mainMenu.Draw(_spriteBatch, viewport);
        base.Draw(gameTime);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Console.WriteLine("[GAME] Shutting down...");
            _discordPresence?.Dispose();
            _discordPresence = null;
            _wallpaper?.Dispose();
            _mainMenu?.Dispose();
            _spriteBatch?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeDiscord()
    {
        _discordPresence = new DiscordPresence();
        _discordPresence.Initialize();
    }

    private static bool ShouldExit()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

        return
            keyboardState.IsKeyDown(Keys.Escape) ||
            gamePadState.Buttons.Back == ButtonState.Pressed;
    }

    private static void LogStartupHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine("""
        
        ██╗  ██╗ █████╗ ██████╗ ██╗   ██╗███████╗███████╗████████╗
        ██║  ██║██╔══██╗██╔══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
        ███████║███████║██████╔╝██║   ██║█████╗  ███████╗   ██║
        ██╔══██║██╔══██║██╔══██╗╚██╗ ██╔╝██╔══╝  ╚════██║   ██║
        ██║  ██║██║  ██║██║  ██║ ╚████╔╝ ███████╗███████║   ██║
        ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝  ╚═══╝  ╚══════╝╚══════╝   ╚═╝

                        🌾  V A L L E Y  🌾
        
        """);

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("              Growing something new.");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"                   Version {GameVersion.Current}");
        Console.WriteLine();

        Console.ResetColor();
    }

    private static void LogEnvironment()
    {
        Console.WriteLine(
            $"[GAME] Starting | " +
            $"{DateTime.Now:MMMM} | " +
            $"{SeasonalIconManager.CurrentSeason}"
        );

        Console.WriteLine(
            $"[ICON] BMP: {SeasonalIconManager.BmpExists()} | " +
            $"ICO: {SeasonalIconManager.IcoExists()} | " +
            $"ICNS: {SeasonalIconManager.IcnsExists()}"
        );
    }
}
