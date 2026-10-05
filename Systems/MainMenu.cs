using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HarvestValley.Systems;

internal sealed class MainMenu : IDisposable
{
    private const int DiscordButtonIndex = 4;
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
    private MouseState _previousMouse;

    public MainMenu(GraphicsDevice graphicsDevice)
    {
        _logo = LoadTexture(graphicsDevice, "mainmenu-logo.png");
        _buttons =
        [
            LoadTexture(graphicsDevice, "button-play.png"),
            LoadTexture(graphicsDevice, "button-load.png"),
            LoadTexture(graphicsDevice, "button-coop.png"),
            LoadTexture(graphicsDevice, "button-exit.png"),
            LoadTexture(graphicsDevice, "button-discord.png")
        ];
        _footerFont = PixelFont.Load(graphicsDevice, Path.Combine(
            AppContext.BaseDirectory, "Assets", "Gui", "Fonts", "MenuPixel.json"));
        _previousMouse = Mouse.GetState();
    }

    public bool Update(Viewport viewport, bool isActive)
    {
        MouseState mouse = Mouse.GetState();
        _hoveredButton = -1;
        if (isActive)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (GetButtonBounds(viewport, i).Contains(mouse.Position))
                    _hoveredButton = i;
            }
        }
        else
        {
            _pressedButton = -1;
        }

        if (mouse.LeftButton == ButtonState.Pressed &&
            _previousMouse.LeftButton == ButtonState.Released)
            _pressedButton = _hoveredButton;

        bool exitRequested = false;
        if (mouse.LeftButton == ButtonState.Released &&
            _previousMouse.LeftButton == ButtonState.Pressed)
        {
            exitRequested = _pressedButton == 3 && _hoveredButton == 3;
            if (_pressedButton == DiscordButtonIndex && _hoveredButton == DiscordButtonIndex)
                OpenDiscord();
            _pressedButton = -1;
        }

        _previousMouse = mouse;
        return exitRequested;
    }

    public void Draw(SpriteBatch spriteBatch, Viewport viewport)
    {
        float scale = GetScale(viewport);
        spriteBatch.Begin(blendState: BlendState.NonPremultiplied,
            samplerState: SamplerState.PointClamp);
        spriteBatch.Draw(_logo, Transform(viewport, new Rectangle(536, 96, 600, 288)),
            new Rectangle(12, 24, 416, 200), Color.White);

        for (int i = 0; i < _buttons.Length; i++)
        {
            Rectangle bounds = GetButtonBounds(viewport, i);
            Color tint = Color.White;
            if (_hoveredButton == i)
            {
                tint = new Color(255, 240, 205);
                if (_pressedButton == i)
                    bounds.Y += Math.Max(1, (int)MathF.Round(3 * scale));
                else
                    bounds.Y -= Math.Max(1, (int)MathF.Round(2 * scale));
            }
            Rectangle? source = i == DiscordButtonIndex ? DiscordButtonSource : null;
            spriteBatch.Draw(_buttons[i], bounds, source, tint);
        }
        spriteBatch.End();

        float fontScale = GetFooterScale(viewport);
        Vector2 footerPosition = GetFooterPosition(viewport);

        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        DrawFooter(spriteBatch, _copyright, footerPosition, fontScale);
        DrawFooter(spriteBatch, _version, new Vector2(
            viewport.Width - footerPosition.X - _footerFont.MeasureString(_version).X * fontScale,
            footerPosition.Y), fontScale);
        spriteBatch.End();
    }

    private void DrawFooter(SpriteBatch spriteBatch, string text, Vector2 position, float scale)
    {
        position = new Vector2(MathF.Round(position.X), MathF.Round(position.Y));
        float shadowOffset = MathF.Round(scale);
        spriteBatch.DrawString(_footerFont, text, position + new Vector2(shadowOffset),
            Color.Black * 0.85f, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        spriteBatch.DrawString(_footerFont, text, position,
            new Color(255, 250, 235), 0, Vector2.Zero, scale, SpriteEffects.None, 0);
    }

    private static float GetScale(Viewport viewport) =>
        Math.Min(viewport.Width / ReferenceSize.X, viewport.Height / ReferenceSize.Y);

    private Rectangle GetButtonBounds(Viewport viewport, int index)
    {
        if (index != DiscordButtonIndex)
            return Transform(viewport, new Rectangle(707, 419 + index * 116, 258, 86));

        float scale = Math.Max(0.75f, GetScale(viewport));
        Vector2 footerPosition = GetFooterPosition(viewport);
        int width = (int)MathF.Round(200 * scale);
        int height = (int)MathF.Round(width * (float)DiscordButtonSource.Height / DiscordButtonSource.Width);
        int gap = (int)MathF.Round(16 * scale);
        return new Rectangle((int)footerPosition.X, (int)footerPosition.Y - gap - height, width, height);
    }

    private float GetFooterScale(Viewport viewport) =>
        Math.Max(2, (int)MathF.Round(3 * GetScale(viewport))) - 4f / _footerFont.LineSpacing;

    private Vector2 GetFooterPosition(Viewport viewport)
    {
        float scale = GetScale(viewport);
        float marginX = MathF.Round(Math.Max(20, 24 * scale));
        float marginY = MathF.Round(Math.Max(16, 16 * scale));
        float textHeight = _footerFont.MeasureString(_copyright).Y * GetFooterScale(viewport);
        return new Vector2(marginX, viewport.Height - marginY - textHeight);
    }

    private static void OpenDiscord()
    {
        try
        {
            using var process = Process.Start(new ProcessStartInfo(DiscordInviteUrl)
            {
                UseShellExecute = true
            });
        }
        catch (Exception ex) when (ex is Win32Exception or InvalidOperationException)
        {
            Console.WriteLine($"[MENU] Could not open Discord invite: {ex.Message}");
        }
    }

    private static Rectangle Transform(Viewport viewport, Rectangle bounds)
    {
        float scale = GetScale(viewport);
        Vector2 offset = (new Vector2(viewport.Width, viewport.Height) - ReferenceSize * scale) / 2;
        return new Rectangle(
            (int)MathF.Round(offset.X + bounds.X * scale),
            (int)MathF.Round(offset.Y + bounds.Y * scale),
            (int)MathF.Round(bounds.Width * scale),
            (int)MathF.Round(bounds.Height * scale));
    }

    private static Texture2D LoadTexture(GraphicsDevice graphicsDevice, string filename)
    {
        using var stream = File.OpenRead(Path.Combine(
            AppContext.BaseDirectory, "Assets", "Gui", "MainMenu", filename));
        return Texture2D.FromStream(graphicsDevice, stream);
    }

    public void Dispose()
    {
        _logo.Dispose();
        _footerFont.Texture.Dispose();
        foreach (Texture2D button in _buttons)
            button.Dispose();
    }
}
