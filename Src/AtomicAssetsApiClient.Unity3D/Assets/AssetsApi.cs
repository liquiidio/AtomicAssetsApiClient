using AtomicAssetsApiClient.Core.Assets;

namespace AtomicAssetsApiClient.Unity3D.Assets
{
    public class AssetsApi : AssetsApiBase
    {
        internal AssetsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}