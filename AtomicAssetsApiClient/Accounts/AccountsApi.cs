
using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountsApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal AccountsApi(string baseUrl) => _requestUriBase = baseUrl;

/// <summary>
/// It returns a list of accounts.
/// </summary>
/// <returns>
/// A list of accounts
/// </returns>
        public AccountsDto Accounts()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AccountsUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AccountsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// It returns a list of accounts.
/// </summary>
/// <param name="AccountsUriParameterBuilder">This is a class that contains all the parameters
/// that can be passed to the Accounts endpoint.</param>
/// <returns>
/// A list of accounts.
/// </returns>
        public AccountsDto Accounts(AccountsUriParameterBuilder accountsUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AccountsUri(accountsUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AccountsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > This function will return an AccountDto object if the API call is successful, otherwise it
/// will throw an exception
/// </summary>
/// <param name="accountName">The name of the account you want to retrieve.</param>
/// <returns>
/// An AccountDto object
/// </returns>
        public AccountDto Account(string accountName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AccountUri(accountName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AccountDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > This function will return an AccountCollectionDto object if the request is successful
/// </summary>
/// <param name="accountName">The name of the account you want to retrieve.</param>
/// <param name="collectionName">The name of the collection you want to retrieve.</param>
/// <returns>
/// An AccountCollectionDto object.
/// </returns>
        public AccountCollectionDto Collection(string accountName, string collectionName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AccountUri(accountName, collectionName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AccountCollectionDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        private Uri AccountsUri() => new Uri($"{_requestUriBase}/accounts");
        private Uri AccountsUri(AccountsUriParameterBuilder accountsUriParameterBuilder) => new Uri($"{_requestUriBase}/accounts{accountsUriParameterBuilder.Build()}");
        private Uri AccountUri(string accountName) => new Uri($"{_requestUriBase}/accounts/{accountName}");
        private Uri AccountUri(string accountName, string collectionName) => new Uri($"{_requestUriBase}/accounts/{accountName}/{collectionName}");
    }
}
