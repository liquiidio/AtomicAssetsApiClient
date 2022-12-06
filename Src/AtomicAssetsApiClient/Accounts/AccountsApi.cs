using AtomicAssetsApiClient.Core.Accounts;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountsApi : AccountsApiBase
    {
        internal AccountsApi(string baseUrl) : base(baseUrl, new HttpHandler())
        {

        }
    }
}