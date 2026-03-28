using SunamoNuGetProtocol.Tests;

namespace RunnerNuGetProtocol;

/// <summary>
/// Entry point for running NuGetProtocol tests outside of the test framework.
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args)
    {
        NuGetProtocolHelperTests t = new NuGetProtocolHelperTests();
        await t.GetPackageVersionsTests();
    }
}
