using System.Diagnostics;
using System.Drawing;
using static SDL2.SDL;

namespace Core.API;

public class Renderer(IntPtr window, Dimensions dimensions, Color backgroundColor) : IRenderer
{
    private IntPtr sdlRenderer;

    public void Init()
    {
        sdlRenderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        Debug.Assert(sdlRenderer != IntPtr.Zero);
    }

    public void DrawRect(in Rectangle rectangle, in Color color)
    {
        SDL_Rect rect = dimensions.GetScaledRect(rectangle);

        SDL_SetRenderDrawColor(sdlRenderer, color.R, color.G, color.B, color.A);
        SDL_RenderFillRect(sdlRenderer, ref rect);
    }

    public void Present()
    {
        SDL_RenderPresent(sdlRenderer);
    }

    public void Clear()
    {
        SDL_SetRenderDrawColor(sdlRenderer, backgroundColor.R, backgroundColor.G, backgroundColor.B, backgroundColor.A);
        SDL_RenderClear(sdlRenderer);
    }
}