using AtomicAssetsApiClient.Core.Templates;

namespace AtomicAssetsApiClient.Unity3D.Templates
{
    public class TemplatesApi : TemplatesApiBase
    {
        internal TemplatesApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}