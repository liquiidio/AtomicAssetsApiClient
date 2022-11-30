using AtomicAssetsApiClient.Core.Collections;

namespace AtomicAssetsApiClient.Collections
{
    public class CollectionsApi : CollectionsApiBase
    {
        internal CollectionsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}