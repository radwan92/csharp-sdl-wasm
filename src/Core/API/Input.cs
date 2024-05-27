using SDL2;

namespace Core.API;

public class Input : IInput
{
    public bool IsKeyPressed(SDL.SDL_Keycode key)
    {
        IntPtr statePtr = SDL.SDL_GetKeyboardState(out int numKeys);

        unsafe
        {
            Span<byte> state = new Span<byte>((void*)statePtr, numKeys);
            SDL.SDL_Scancode scancode = SDL.SDL_GetScancodeFromKey(key);
            return state[(byte)scancode] == 1;
        }
    }
}