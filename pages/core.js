let canvas = document.getElementById('canvas');
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;

var Module = {
    canvas: canvas,
    onRuntimeInitialized: () => {
        // Could call _WasmMain directly, but I couldn't get it to work with string param
        Module.ccall('WasmMain', 'void', ['string'], [simulation]);
    }
};