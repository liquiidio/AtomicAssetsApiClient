using AtomicAssetsApiClient.Core.Collections;

namespace AtomicAssetsApiClient.Unity3D.Collections
{
    public class CollectionsApi : CollectionsApiBase
    {
        internal CollectionsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}