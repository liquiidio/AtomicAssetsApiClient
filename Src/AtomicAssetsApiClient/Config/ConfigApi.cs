using AtomicAssetsApiClient.Core.Config;

namespace AtomicAssetsApiClient.Config
{
    public class ConfigApi : ConfigApiBase
    {
        internal ConfigApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {
        }
    }
}