using AtomicAssetsApiClient.Core.Transfers;

namespace AtomicAssetsApiClient.Unity3D.Transfers
{
    public class TransfersApi : TransfersApiBase
    {
        internal TransfersApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}