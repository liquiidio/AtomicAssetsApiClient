using AtomicAssetsApiClient.Core.Offers;

namespace AtomicAssetsApiClient.Offers
{
    public class OffersApi : OffersApiBase
    {
        internal OffersApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {
        }
    }
}