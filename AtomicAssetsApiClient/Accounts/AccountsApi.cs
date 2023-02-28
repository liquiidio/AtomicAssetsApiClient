using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountsApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHandler;

        internal AccountsApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHandler = httpHandler;
        }

        /// <summary>
        /// It returns a list of accounts.
        /// </summary>
        /// <returns>
        /// A list of accounts
        /// </returns>
        public async Task<AccountsDto> Accounts()
        {
            return await _httpHandler.GetJsonAsync<AccountsDto>(AccountsUri().OriginalString);
        }

        /// <summary>
        /// It returns a list of accounts.
        /// </summary>
        /// <param name="AccountsUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the Accounts endpoint.</param>
        /// <returns>
        /// A list of accounts.
        /// </returns>
        public async Task<AccountsDto> Accounts(AccountsUriParameterBuilder accountsUriParameterBuilder)
        {
            return await _httpHandler.GetJsonAsync<AccountsDto>(AccountsUri(accountsUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// This function will return an AccountDto object if the API call is successful, otherwise it
        /// will throw an exception
        /// </summary>
        /// <param name="accountName">The name of the account you want to retrieve.</param>
        /// <returns>
        /// An AccountDto object
        /// </returns>
        public async Task<AccountDto> Account(string accountName)
        {
            return await _httpHandler.GetJsonAsync<AccountDto>(AccountUri(accountName).OriginalString);
        }

        /// <summary>
        /// This function will return an AccountCollectionDto object if the request is successful
        /// </summary>
        /// <param name="accountName">The name of the account you want to retrieve.</param>
        /// <param name="collectionName">The name of the collection you want to retrieve.</param>
        /// <returns>
        /// An AccountCollectionDto object.
        /// </returns>
        public async Task<AccountCollectionDto> Collection(string accountName, string collectionName)
        {
            return await _httpHandler.GetJsonAsync<AccountCollectionDto>(AccountUri(accountName, collectionName).OriginalString);
        }

        /// <summary>
        /// It returns a URI for the accounts endpoint
        /// </summary>
        private Uri AccountsUri() => new Uri($"{_requestUriBase}/accounts");

        /// <summary>
        /// It takes an `AccountsUriParameterBuilder` object and returns a `Uri` object.
        /// </summary>
        /// <param name="AccountsUriParameterBuilder">A class that builds the query string parameters
        /// for the accounts endpoint.</param>
        private Uri AccountsUri(AccountsUriParameterBuilder accountsUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/accounts{accountsUriParameterBuilder.Build()}");

        /// <summary>
        /// Given an account name, return a URI for the account.
        /// </summary>
        /// <param name="accountName">The name of the account to be created.</param>
        private Uri AccountUri(string accountName) => new Uri($"{_requestUriBase}/accounts/{accountName}");

        /// <summary>
        /// > It returns a URI for a given account name and collection name
        /// </summary>
        /// <param name="accountName">The name of the account.</param>
        /// <param name="collectionName">The name of the collection you want to access.</param>
        private Uri AccountUri(string accountName, string collectionName) =>
            new Uri($"{_requestUriBase}/accounts/{accountName}/{collectionName}");
    }
}