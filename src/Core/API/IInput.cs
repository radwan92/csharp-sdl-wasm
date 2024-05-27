using SDL2;

namespace Core.API;

public interface IInput
{
    bool IsKeyPressed(SDL.SDL_Keycode key);
}