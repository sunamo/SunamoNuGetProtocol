using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

namespace SunamoNuGetProtocol;
//
public class NuGetProtocolHelper
{
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
            take: int.MaxValue,
            logger,
            cancellationToken);

        return results.ToList();
    }
}
