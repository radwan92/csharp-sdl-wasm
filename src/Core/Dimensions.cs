using System.Drawing;

public struct Dimensions
{
    public uint SizeInPixels { get; }
    public uint Width { get; }
    public uint Height { get; }

    public uint PixelWidth => Width * SizeInPixels;
    public uint PixelHeight => Height * SizeInPixels;

    public Dimensions(uint sizeInPixels, uint width, uint height)
    {
        SizeInPixels = sizeInPixels;
        Width = width;
        Height = height;
    }

    public readonly void ScaleRect(ref Rectangle rect)
    {
        rect.X *= (int)SizeInPixels;
        rect.Y *= (int)SizeInPixels;
        rect.Width *= (int)SizeInPixels;
        rect.Height *= (int)SizeInPixels;
    }

    public readonly Rectangle GetScaledRect(in Rectangle rect)
    {
        return new Rectangle(
            rect.X * (int)SizeInPixels,
            rect.Y * (int)SizeInPixels,
            rect.Width * (int)SizeInPixels,
            rect.Height * (int)SizeInPixels);
    }

    public readonly void ScalePoint(ref Point point)
    {
        point.X *= (int)SizeInPixels;
        point.Y *= (int)SizeInPixels;
    }

    public readonly Point GetScaledPoint(in Point point)
    {
        return new Point(
            point.X * (int)SizeInPixels,
            point.Y * (int)SizeInPixels);
    }
}