using AtomicAssetsApiClient.Unity3D.Accounts;
using AtomicAssetsApiClient.Unity3D.Assets;
using AtomicAssetsApiClient.Unity3D.Burns;
using AtomicAssetsApiClient.Unity3D.Collections;
using AtomicAssetsApiClient.Unity3D.Config;
using AtomicAssetsApiClient.Unity3D.Offers;
using AtomicAssetsApiClient.Unity3D.Schemas;
using AtomicAssetsApiClient.Unity3D.Templates;
using AtomicAssetsApiClient.Unity3D.Transfers;

namespace AtomicAssetsApiClient.Unity3D
{
    public class AtomicAssetsApiFactory
    {
        private readonly string _baseUrl;
        private const string Version1BaseUrl = "http://wax.api.atomicassets.io/atomicassets/v1";

        private AtomicAssetsApiFactory(string baseUrl) => _baseUrl = baseUrl;

        public static AtomicAssetsApiFactory Version1 => new AtomicAssetsApiFactory(Version1BaseUrl);

        public AccountsApi AccountsApi => new AccountsApi(_baseUrl);

        public AssetsApi AssetsApi => new AssetsApi(_baseUrl);
        
        public BurnsApi BurnsApi => new BurnsApi(_baseUrl);

        public CollectionsApi CollectionsApi => new CollectionsApi(_baseUrl);
        
        public ConfigApi ConfigApi => new ConfigApi(_baseUrl);
        
        public OffersApi OffersApi => new OffersApi(_baseUrl);

        public SchemasApi SchemasApi => new SchemasApi(_baseUrl);
        
        public TemplatesApi TemplatesApi => new TemplatesApi(_baseUrl);
        
        public TransfersApi TransfersApi => new TransfersApi(_baseUrl);
    }
}
