namespace HarvestValley.Characters;

internal static partial class Directions
{
    public static string AssetFolder(this Direction8 direction) => direction switch
    {
        Direction8.NorthEast => "North-east",
        Direction8.SouthEast => "South-east",
        Direction8.SouthWest => "South-west",
        Direction8.NorthWest => "North-west",
        _ => direction.ToString()
    };
}
