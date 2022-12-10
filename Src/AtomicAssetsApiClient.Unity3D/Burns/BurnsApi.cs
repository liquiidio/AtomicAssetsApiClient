using AtomicAssetsApiClient.Core.Burns;

namespace AtomicAssetsApiClient.Unity3D.Burns
{
    public class BurnsApi : BurnsApiBase
    { 
        internal BurnsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}