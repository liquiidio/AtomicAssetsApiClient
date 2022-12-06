using AtomicAssetsApiClient.Core.Config;

namespace AtomicAssetsApiClient.Unity3D.Config
{
    public class ConfigApi : ConfigApiBase
    {
        internal ConfigApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {
        }
    }
}