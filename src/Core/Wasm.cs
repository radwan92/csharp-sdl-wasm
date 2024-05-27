using System.Runtime.InteropServices;

namespace Core;

public class Wasm
{
    [DllImport("*", EntryPoint = "emscripten_set_main_loop")]
    private static extern unsafe void emscripten_set_main_loop(delegate* unmanaged<void> loopFunc, int fps, int simulateInfiniteLoop);

    [DllImport("*", EntryPoint = "emscripten_get_canvas_element_size")]
    private static extern unsafe void emscripten_get_canvas_element_size(byte* target, out int width, out int height);

    private static Action loopFunc = () => { };

    public static (uint width, uint height) GetCanvasSize()
    {
        unsafe
        {
            ReadOnlySpan<byte> canvas = "canvas\0"u8;
            fixed (byte* target = canvas)
            {
                emscripten_get_canvas_element_size(target, out int width, out int height);
                return ((uint)width, (uint)height);
            }
        }
    }

    public static void SetMainLoop(Action loopFunc, Action? firstTickFunc = null)
    {
        SetMainLoopCallback(loopFunc, firstTickFunc);

        unsafe
        {
            // This is a never returning call
            emscripten_set_main_loop(&EmscriptenTick, 0, 1);
        }
    }

    private static void SetMainLoopCallback(Action loopFunc, Action? firstTickFunc)
    {
        if (firstTickFunc != null)
        {
            Wasm.loopFunc = () =>
            {
                firstTickFunc();
                Wasm.loopFunc = loopFunc;
            };
        }
        else
        {
            Wasm.loopFunc = loopFunc;
        }
    }

    [UnmanagedCallersOnly]
    private static void EmscriptenTick()
    {
        loopFunc();
    }
}