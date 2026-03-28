namespace SunamoNuGetProtocol.Tests;

/// <summary>
/// Tests for <see cref="NuGetProtocolHelper"/>.
/// </summary>
public class NuGetProtocolHelperTests
{
    /// <summary>
    /// Verifies that GetPackageVersions returns at least one version for an existing package.
    /// </summary>
    [Fact]
    public async Task GetPackageVersionsTests()
    {
        var versions = await NuGetProtocolHelper.GetPackageVersions("SunamoExtensions");

        Assert.NotNull(versions);
        Assert.NotEmpty(versions);
    }
}