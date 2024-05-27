using System.Drawing;
using Core;
using Core.API;
using SDL2;

namespace Simulations;

public class BasicSimulation : Simulation
{
    RectangleF movingBox = new(0, 0, 20, 20);
    float speed = 250.0f;

    public override void Tick(double deltaTime)
    {
        if (Input.IsKeyPressed(SDL.SDL_Keycode.SDLK_LEFT))
        {
            movingBox.X -= (float)(speed * deltaTime);
        }
        if (Input.IsKeyPressed(SDL.SDL_Keycode.SDLK_RIGHT))
        {
            movingBox.X += (float)(speed * deltaTime);
        }
        if (Input.IsKeyPressed(SDL.SDL_Keycode.SDLK_UP))
        {
            movingBox.Y -= (float)(speed * deltaTime);
        }
        if (Input.IsKeyPressed(SDL.SDL_Keycode.SDLK_DOWN))
        {
            movingBox.Y += (float)(speed * deltaTime);
        }
    }

    public override void Render()
    {
        Renderer.DrawRect(movingBox.ToRectangle(), Color.Blue);
    }

    public static void Run()
    {
        var engine = new EngineBuilder()
            .WithStretchedDimensions(1)
            .WithBackgroundColor(Color.Black)
            .WithSimulation(new BasicSimulation())
            .Build();

        engine.Start();
    }
}