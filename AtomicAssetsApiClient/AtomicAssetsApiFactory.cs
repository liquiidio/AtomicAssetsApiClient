using AtomicAssetsApiClient.Accounts;
using AtomicAssetsApiClient.Assets;
using AtomicAssetsApiClient.Burns;
using AtomicAssetsApiClient.Collections;
using AtomicAssetsApiClient.Config;
using AtomicAssetsApiClient.Offers;
using AtomicAssetsApiClient.Schemas;
using AtomicAssetsApiClient.Templates;
using AtomicAssetsApiClient.Transfers;

namespace AtomicAssetsApiClient
{
    public class AtomicAssetsApiFactory
    {
        private readonly string _baseUrl;
        private const string Version1BaseUrl = "http://wax.api.atomicassets.io/atomicassets/v1";

        private AtomicAssetsApiFactory(string baseUrl) => _baseUrl = baseUrl;

        public static AtomicAssetsApiFactory Version1 => new AtomicAssetsApiFactory(Version1BaseUrl);

#if !UNITY
        public AccountsApi AccountsApi => new AccountsApi(_baseUrl, new HttpClientHandler());

        public AssetsApi AssetsApi => new AssetsApi(_baseUrl, new HttpClientHandler());

        public BurnsApi BurnsApi => new BurnsApi(_baseUrl, new HttpClientHandler());

        public CollectionsApi CollectionsApi => new CollectionsApi(_baseUrl, new HttpClientHandler());

        public ConfigApi ConfigApi => new ConfigApi(_baseUrl, new HttpClientHandler());

        public OffersApi OffersApi => new OffersApi(_baseUrl, new HttpClientHandler());

        public SchemasApi SchemasApi => new SchemasApi(_baseUrl, new HttpClientHandler());

        public TemplatesApi TemplatesApi => new TemplatesApi(_baseUrl, new HttpClientHandler());

        public TransfersApi TransfersApi => new TransfersApi(_baseUrl, new HttpClientHandler());
#else
        public AccountsApi AccountsApi => new AccountsApi(_baseUrl, new UnityWebRequestHandler());

        public AssetsApi AssetsApi => new AssetsApi(_baseUrl, new UnityWebRequestHandler());

        public BurnsApi BurnsApi => new BurnsApi(_baseUrl, new UnityWebRequestHandler());

        public CollectionsApi CollectionsApi => new CollectionsApi(_baseUrl, new UnityWebRequestHandler());

        public ConfigApi ConfigApi => new ConfigApi(_baseUrl, new UnityWebRequestHandler());

        public OffersApi OffersApi => new OffersApi(_baseUrl, new UnityWebRequestHandler());

        public SchemasApi SchemasApi => new SchemasApi(_baseUrl, new UnityWebRequestHandler());

        public TemplatesApi TemplatesApi => new TemplatesApi(_baseUrl, new UnityWebRequestHandler());

        public TransfersApi TransfersApi => new TransfersApi(_baseUrl, new UnityWebRequestHandler());
#endif
    }
}
