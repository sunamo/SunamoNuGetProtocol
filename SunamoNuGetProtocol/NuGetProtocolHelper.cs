// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoNuGetProtocol;
//
public class NuGetProtocolHelper
{
    /// <summary>
    ///     trochu nefunguje
    ///     dnes jsem pushoval 3 nové packages, přesto mi to vrací stále 20
    ///     nuget search vracelo taky 20
    ///     řešení je volat dot_net nuget locals --clear all neboli dnlc před tím
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public static async Task<List<IPackageSearchMetadata>> SearchNugetPackages(string query)
    {
        var logger = NuGet.Common.NullLogger.Instance;
        var cancellationToken = CancellationToken.None;
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<PackageSearchResource>();
        var searchFilter = new SearchFilter(true);
        IEnumerable<IPackageSearchMetadata> results = await resource.SearchAsync(
            query,
            searchFilter,
            0,
            // z nějakého důvodu short.maxvalue i int.maxvalue mi vraceli default 20. 1000 bude dostatečné pro všechny účely
            1000,
            logger,
            cancellationToken);
        return results.ToList();
    }
    public static async Task<IEnumerable< /*NuGet.Protocol.Core.VersionInfo*/ NuGetVersion>> GetPackageVersions(
        string packageId)
    {
        var logger = NuGet.Common.NullLogger.Instance;
        var cancellationToken = CancellationToken.None;
        var cache = new SourceCacheContext();
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<FindPackageByIdResource>(cancellationToken);
        return await resource.GetAllVersionsAsync(packageId, cache, logger, cancellationToken);
    }
}