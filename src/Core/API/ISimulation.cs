namespace Core.API;

public interface ISimulation
{
    void Tick(double deltaTime);
    void Render();
    void SetAPI(in EngineAPI api);
}