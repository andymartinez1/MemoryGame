using MemoryGame.Models;

namespace MemoryGame.Helpers;

public static class ColorExtensions
{
    public static string GetBackground(this Color color)
    {
        return color switch
        {
            Color.Red => "#e74c3c",
            Color.Orange => "#e67e22",
            Color.Yellow => "#f1c40f",
            Color.Green => "#2ecc71",
            Color.Blue => "#3498db",
            Color.Purple => "#9b59b6",
            _ => "#ffffff"
        };
    }

    public static string GetTextColor(this Color color)
    {
        return color switch
        {
            Color.Yellow => "#000000",
            _ => "#ffffff"
        };
    }
}