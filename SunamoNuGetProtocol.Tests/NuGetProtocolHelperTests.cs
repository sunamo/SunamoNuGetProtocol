// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoNuGetProtocol.Tests;

public class NuGetProtocolHelperTests
{
    [Fact]
    public async Task GetPackageVersionsTests()
    {
        var data = await NuGetProtocolHelper.GetPackageVersions("SunamoExtensions");
    }
}