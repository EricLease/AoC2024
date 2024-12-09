using System.Drawing;

namespace Utilities;

public static class Extensions
{
    public static List<string> GetLines(this string input)
        => [..input.Split(
            Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        ];

    public static bool InBounds(this Point point, int width, int height)
        => point.X >= 0 && point.X < width && point.Y >= 0 && point.Y < height;
}