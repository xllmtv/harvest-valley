using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HarvestValley.Discord;
using HarvestValley.Systems;

namespace HarvestValley;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch = null!;
    private DiscordPresence? _discordPresence;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Title = "Harvest Valley";

        Console.WriteLine("======================================");
        Console.WriteLine(" Harvest Valley (0.0.1)");
        Console.WriteLine("======================================");
    }

    protected override void Initialize()
    {
        RealWorldSeason season = SeasonalIconManager.GetCurrentSeason();

        string bmpPath = SeasonalIconManager.GetBmpPath();
        string icoPath = SeasonalIconManager.GetIcoPath();

        Console.WriteLine(
            $"[GAME] Starting | {DateTime.Now:MMMM} | {season}"
        );

        Console.WriteLine(
            $"[ICON] BMP: {File.Exists(bmpPath)} | ICO: {File.Exists(icoPath)}"
        );

        _discordPresence = new DiscordPresence();
        _discordPresence.Initialize();

        base.Initialize();

        Console.WriteLine("[GAME] Ready.");
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
        {
            Console.WriteLine("[GAME] Exit requested.");
            Exit();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        base.Draw(gameTime);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Console.WriteLine("[GAME] Shutting down...");

            _discordPresence?.Dispose();
            _spriteBatch?.Dispose();
        }

        base.Dispose(disposing);
    }
}