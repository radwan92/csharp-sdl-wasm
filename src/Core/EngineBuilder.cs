using System.Diagnostics;
using System.Drawing;
using Core.API;
using static SDL2.SDL;

namespace Core;

public struct EngineBuilder
{
    public Dimensions Dimensions;
    public Color BackgroundColor;
    public ISimulation Simulation;
    public string Title;

    public Engine Build()
    {
        return new Engine(Title, Dimensions, BackgroundColor, Simulation);
    }

    public EngineBuilder WithDimensions(in Dimensions dimensions)
    {
        Dimensions = dimensions;
        return this;
    }

    public EngineBuilder WithStretchedDimensions(uint pointSize)
    {
        (uint width, uint height) = GetScreenSize();
        (width, height) = (width / pointSize, height / pointSize);
        return WithDimensions(new Dimensions(pointSize, width, height));
    }

    public EngineBuilder WithBackgroundColor(in Color backgroundColor)
    {
        BackgroundColor = backgroundColor;
        return this;
    }

    public EngineBuilder WithSimulation(ISimulation simulation)
    {
        Simulation = simulation;
        return this;
    }

    public EngineBuilder WithTitle(string title)
    {
        Title = title;
        return this;
    }

    private static (uint width, uint heigh) GetScreenSize()
    {
        return Platform.Execute(
            GetScreenSize_Default,
            GetScreenSize_Wasm);

        static (uint width, uint height) GetScreenSize_Default()
        {
            int result = SDL_Init(SDL_INIT_VIDEO);
            Debug.Assert(result == 0);

            result = SDL_GetDisplayBounds(0, out SDL_Rect screenSize);
            Debug.Assert(result == 0);

            return result == 0
                ? ((uint)screenSize.w, (uint)screenSize.h)
                : (640, 480);
        }

        static (uint width, uint height) GetScreenSize_Wasm()
        {
            return Wasm.GetCanvasSize();
        }
    }
}