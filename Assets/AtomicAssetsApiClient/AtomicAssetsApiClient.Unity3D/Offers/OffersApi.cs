using AtomicAssetsApiClient.Core.Offers;

namespace AtomicAssetsApiClient.Unity3D.Offers
{
    public class OffersApi : OffersApiBase
    {
        internal OffersApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {
        }
    }
}