using AtomicAssetsApiClient.Core.Schemas;

namespace AtomicAssetsApiClient.Schemas
{
    public class SchemasApi : SchemasApiBase
    {
        internal SchemasApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}