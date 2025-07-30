namespace SunamoNuGetProtocol.Tests;

public class NuGetProtocolHelperTests
{
    [Fact]
    public async Task GetPackageVersionsTests()
    {
        var d = await NuGetProtocolHelper.GetPackageVersions("SunamoExtensions");
    }
}