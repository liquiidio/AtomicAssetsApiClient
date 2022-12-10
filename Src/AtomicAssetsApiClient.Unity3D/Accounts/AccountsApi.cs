using AtomicAssetsApiClient.Core.Accounts;

namespace AtomicAssetsApiClient.Unity3D.Accounts
{
    public class AccountsApi : AccountsApiBase
    {
        internal AccountsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}