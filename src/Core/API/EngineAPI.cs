namespace Core.API;

public record struct EngineAPI(IInput Input, IRenderer Renderer, Dimensions dimensions);
