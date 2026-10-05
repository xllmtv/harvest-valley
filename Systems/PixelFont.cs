using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Systems;

internal static class PixelFont
{
    public static SpriteFont Load(GraphicsDevice graphicsDevice, string path)
    {
        var patterns = JsonSerializer.Deserialize<Dictionary<char, string>>(
            File.ReadAllText(path)) ?? throw new InvalidDataException("Missing pixel font glyphs.");
        var characters = patterns.Keys.OrderBy(c => c).ToList();
        const int cellSize = 10;
        const int columns = 16;
        int textureWidth = columns * cellSize;
        int textureHeight = (characters.Count + columns - 1) / columns * cellSize;
        var pixels = new Color[textureWidth * textureHeight];
        var bounds = new List<Rectangle>();
        var cropping = new List<Rectangle>();
        var kerning = new List<Vector3>();

        for (int i = 0; i < characters.Count; i++)
        {
            string[] rows = patterns[characters[i]].Split('/');
            int width = rows[0].Length;
            if (width is < 1 or > 8 || rows.Length is < 1 or > 8 ||
                rows.Any(row => row.Length != width || row.Any(pixel => pixel is not ('0' or '1'))))
                throw new InvalidDataException($"Invalid pixel font glyph: {characters[i]}");

            int left = i % columns * cellSize + 1;
            int top = i / columns * cellSize + 1;
            for (int y = 0; y < rows.Length; y++)
                for (int x = 0; x < width; x++)
                    if (rows[y][x] == '1')
                        pixels[(top + y) * textureWidth + left + x] = Color.White;

            bounds.Add(new Rectangle(left, top, width, 8));
            cropping.Add(new Rectangle(0, 0, width, 8));
            kerning.Add(new Vector3(0, width, 0));
        }

        var texture = new Texture2D(graphicsDevice, textureWidth, textureHeight);
        texture.SetData(pixels);
        return new SpriteFont(texture, bounds, cropping, characters, 8, 1, kerning, '?');
    }
}
