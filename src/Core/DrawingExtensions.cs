using System.Drawing;

namespace Core;

public static class DrawingExtensions
{
    public static Rectangle ToRectangle(this RectangleF rectangle)
    {
        return new Rectangle((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width, (int)rectangle.Height);
    }
}