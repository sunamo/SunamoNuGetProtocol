namespace RunnerNuGetProtocol;

using SunamoNuGetProtocol.Tests;

internal class Program
{
    static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
        NuGetProtocolHelperTests t = new NuGetProtocolHelperTests();
        await t.GetPackageVersionsTests();
    }
}