using System.Diagnostics;
using System.Drawing;
using Core.API;
using SDL2;

namespace Core;

using static SDL;

public class Engine
{
    private readonly Input input = new();
    private readonly Renderer renderer;
    private readonly ISimulation simulation;

    private bool isRunning = true;
    private DateTime lastTickTime;

    public Engine(string title, in Dimensions dimensions, Color backgroundColor, ISimulation simulation)
    {
        this.simulation = simulation;

        int init = SDL_Init(SDL_INIT_EVERYTHING);
        Debug.Assert(init == 0);

        IntPtr window = SDL_CreateWindow(title,
            SDL_WINDOWPOS_CENTERED,
            SDL_WINDOWPOS_CENTERED,
            (int)dimensions.PixelWidth,
            (int)dimensions.PixelHeight,
            SDL_WindowFlags.SDL_WINDOW_SHOWN);
        Debug.Assert(window != IntPtr.Zero);

        renderer = new(window, dimensions, backgroundColor);

        simulation.SetAPI(new EngineAPI(input, renderer, dimensions));
    }

    public void Start()
    {
        lastTickTime = DateTime.UtcNow;

        Platform.Execute(
            Start_Default,
            Start_Wasm);
    }

    private void Start_Default()
    {
        renderer.Init();

        while (isRunning)
        {
            Tick();

            Thread.Sleep(TimeSpan.FromSeconds(1.0 / 60.0));
        }
    }

    private void Start_Wasm()
    {
        Wasm.SetMainLoop(Tick, () => { renderer.Init(); } );
    }

    private void Tick()
    {
        DateTime now = DateTime.UtcNow;
        var deltaTime = now - lastTickTime;

        while(SDL_PollEvent(out SDL_Event sdlEvent) != 0)
        {
            switch(sdlEvent.type)
            {
                case SDL_EventType.SDL_QUIT:
                case SDL_EventType.SDL_KEYDOWN when sdlEvent.key.keysym.sym == SDL_Keycode.SDLK_ESCAPE:
                    isRunning = false;
                    break;
            }
        }

        simulation.Tick(deltaTime.TotalSeconds);

        renderer.Clear();
        simulation.Render();
        renderer.Present();

        lastTickTime = now;
    }
}