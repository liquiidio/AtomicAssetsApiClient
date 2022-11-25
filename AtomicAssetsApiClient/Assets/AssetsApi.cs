using AtomicAssetsApiClient.Core.Assets;

namespace AtomicAssetsApiClient.Assets
{
    public class AssetsApi : AssetsApiBase
    {
        internal AssetsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}