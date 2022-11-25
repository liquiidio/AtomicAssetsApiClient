using AtomicAssetsApiClient.Core.Transfers;

namespace AtomicAssetsApiClient.Transfers
{
    public class TransfersApi : TransfersApiBase
    {
        internal TransfersApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}