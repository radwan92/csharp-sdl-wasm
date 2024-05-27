namespace Core;

public static class Platform
{
    public static void Execute(
        Action defaultPlatform,
        Action wasm)
    {
#if PLATFORM_WASM
        wasm();
#else
        defaultPlatform();
#endif
    }

    public static TRet Execute<TRet>(
        Func<TRet> defaultPlatform,
        Func<TRet> wasm)
    {
#if PLATFORM_WASM
        return wasm();
#else
        return defaultPlatform();
#endif
    }

}