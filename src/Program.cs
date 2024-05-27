using System.Diagnostics;
using System.Runtime.InteropServices;
using Simulations;

public class Program
{
    const string SIM_BASIC_SIMULATION = "BasicSimulation";

    public static void Main()
    {
        Run(SIM_BASIC_SIMULATION);
    }

    // WASM entry point
    [UnmanagedCallersOnly(EntryPoint = "WasmMain")]
    private static void WasmMain(IntPtr simulationNamePtr)
    {
        string? ptrToStringUtf8 = Marshal.PtrToStringUTF8(simulationNamePtr);
        Debug.Assert(ptrToStringUtf8 != null);
        Run(ptrToStringUtf8);
    }

    private static void Run(string simulationName)
    {
        Console.WriteLine($"Running simulation: {simulationName}");

        switch (simulationName)
        {
            case SIM_BASIC_SIMULATION:
                BasicSimulation.Run();
                break;
        }
    }
}