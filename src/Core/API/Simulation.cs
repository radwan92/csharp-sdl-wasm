namespace Core.API;

public abstract class Simulation : ISimulation
{
    protected IInput Input { get; private set; } = null!;
    protected IRenderer Renderer { get; private set; } = null!;

    public abstract void Tick(double deltaTime);
    public abstract void Render();

    public void SetAPI(in EngineAPI api)
    {
        Input = api.Input;
        Renderer = api.Renderer;
    }

}