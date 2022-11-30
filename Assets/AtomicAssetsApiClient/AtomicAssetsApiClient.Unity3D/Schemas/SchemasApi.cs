using AtomicAssetsApiClient.Core.Schemas;

namespace AtomicAssetsApiClient.Unity3D.Schemas
{
    public class SchemasApi : SchemasApiBase
    {
        internal SchemasApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}