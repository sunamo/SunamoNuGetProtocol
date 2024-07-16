
namespace SunamoNuGetProtocol;
using NuGet.Versioning;

//
public class NuGetProtocolHelper
{
    /// <summary>
    /// trochu nefunguje
    ///
    /// dnes jsem pushoval 3 nové packages, přesto mi to vrací stále 20
    /// nuget search vracelo taky 20
    ///
    /// řešení je volat dotnet nuget locals --clear all neboli dnlc před tím
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public static async Task<List<IPackageSearchMetadata>> SearchNugetPackages(string query)
    {
        ILogger logger = NullLogger.Instance;
        CancellationToken cancellationToken = CancellationToken.None;

        SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        PackageSearchResource resource = await repository.GetResourceAsync<PackageSearchResource>();
        SearchFilter searchFilter = new SearchFilter(includePrerelease: true);

        IEnumerable<IPackageSearchMetadata> results = await resource.SearchAsync(
        query,
        searchFilter,
        skip: 0,
        // z nějakého důvodu short.maxvalue i int.maxvalue mi vraceli default 20. 1000 bude dostatečné pro všechny účely
        take: 1000,
        logger,
        cancellationToken);

        return results.ToList();
    }

    public static async Task<IEnumerable</*NuGet.Protocol.Core.VersionInfo*/ NuGetVersion>> GetPackageVersions(string packageId)
    {
        var logger = NullLogger.Instance;
        var cancellationToken = CancellationToken.None;

        var cache = new SourceCacheContext();
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<FindPackageByIdResource>(cancellationToken);

        return await resource.GetAllVersionsAsync(packageId, cache, logger, cancellationToken);
    }
}