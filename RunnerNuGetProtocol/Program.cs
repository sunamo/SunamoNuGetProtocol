using SunamoNuGetProtocol.Tests;

namespace RunnerNuGetProtocol;

internal class Program
{
    static void Main()
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args)
    {
        NuGetProtocolHelperTests t = new NuGetProtocolHelperTests();
        await t.GetPackageVersionsTests();
    }
}
