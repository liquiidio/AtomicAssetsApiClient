using AtomicAssetsApiClient.Core.Templates;

namespace AtomicAssetsApiClient.Templates
{
    public class TemplatesApi : TemplatesApiBase
    {
        internal TemplatesApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}