using AtomicAssetsApiClient.Core.Burns;

namespace AtomicAssetsApiClient.Burns
{
    public class BurnsApi : BurnsApiBase
    { 
        internal BurnsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}