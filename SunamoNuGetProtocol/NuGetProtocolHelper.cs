namespace SunamoNuGetProtocol;

public class NuGetProtocolHelper
{
    // Note: NuGet API may cache results. Run "dotnet nuget locals --clear all" to clear the cache before searching.
    public static async Task<List<IPackageSearchMetadata>> SearchNugetPackages(string query)
    {
        var nugetLogger = NuGet.Common.NullLogger.Instance;
        var cancellationToken = CancellationToken.None;
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<PackageSearchResource>();
        var searchFilter = new SearchFilter(true);
        IEnumerable<IPackageSearchMetadata> results = await resource.SearchAsync(
            query,
            searchFilter,
            0,
            1000,
            nugetLogger,
            cancellationToken);
        return results.ToList();
    }

    /// <summary>
    /// Retrieves all available versions of a specified NuGet package.
    /// </summary>
    /// <param name="packageId">The unique identifier of the NuGet package.</param>
    /// <returns>An enumerable of all available NuGet versions for the specified package.</returns>
    public static async Task<IEnumerable<NuGetVersion>> GetPackageVersions(string packageId)
    {
        var nugetLogger = NuGet.Common.NullLogger.Instance;
        var cancellationToken = CancellationToken.None;
        var cache = new SourceCacheContext();
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<FindPackageByIdResource>(cancellationToken);
        return await resource.GetAllVersionsAsync(packageId, cache, nugetLogger, cancellationToken);
    }
}
