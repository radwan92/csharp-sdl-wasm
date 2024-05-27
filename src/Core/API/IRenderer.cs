using System.Drawing;
using SDL2;

namespace Core.API;

public interface IRenderer
{
    void DrawRect(in Rectangle rectangle, in Color color);
}
