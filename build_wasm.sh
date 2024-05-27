# !/bin/bash

dotnet publish -r browser-wasm -c Release
if [ $? -ne 0 ]; then
    echo "dotnet publish failed"
    exit 1
fi

cp ./bin/Release/net8.0/browser-wasm/publish/csharp-sdl-wasm.js ./pages
cp ./bin/Release/net8.0/browser-wasm/publish/csharp-sdl-wasm.wasm ./pages