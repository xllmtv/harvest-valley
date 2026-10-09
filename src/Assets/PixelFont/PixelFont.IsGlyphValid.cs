namespace HarvestValley.Assets;

internal static partial class PixelFont
{
    private static bool IsGlyphValid(string[] rows)
    {
        if (rows.Length is < 1 or > 8 || rows[0].Length is < 1 or > 8)
        {
            return false;
        }

        int width = rows[0].Length;
        foreach (string row in rows)
        {
            if (row.Length != width)
            {
                return false;
            }

            foreach (char pixel in row)
            {
                if (pixel is not ('0' or '1'))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
