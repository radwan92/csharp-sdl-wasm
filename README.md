# C#-SDL-WASM Playground

This is a simple project to test the capabilities of C# and SDL2 in a WebAssembly environment.

You can see it in action [here](https://radwan92.github.io/csharp-sdl-wasm).

## Usage

### Building for WASM (Web)

#### Prerequisites

_.NET 8_

Follow the instruction on the [Microsoft website](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

_Emscripten_

Follow the instructions on the [Emscripten website](https://emscripten.org/docs/getting_started/downloads.html).

_python_

> :warning: Not strictly required - used by the local web server script (serve.sh).

Follow the instructions on the [Python website](https://www.python.org/downloads).

#### Building

To build for WASM use the `./build_wasm.sh` script. 
It builds the project and copies necessary files to the `./pages` directory.

### Testing Web builds locally

After building the project for WASM, you can execute the `./serve.sh` which will start a simple HTTP server on
port 8080.
You can then access the project by navigating to `http://localhost:8080` in your browser.

### Resources

- [AOT compilation documentation](https://github.com/dotnet/runtimelab/blob/feature/NativeAOT-LLVM/docs/using-nativeaot/compiling.md)
- [SDL2-CS](https://github.com/flibitijibibo/SDL2-CS)