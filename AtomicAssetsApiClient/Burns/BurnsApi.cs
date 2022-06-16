using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Burns
{
    public class BurnsApi
    { 
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal BurnsApi(string baseUrl) => _requestUriBase = baseUrl;

/// <summary>
/// > This function will make a GET request to the Burns endpoint and return the response as a
/// BurnsDto object
/// </summary>
/// <returns>
/// BurnsDto
/// </returns>
        public BurnsDto Burns()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(BurnsUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<BurnsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > This function will return a BurnsDto object if the API call is successful. Otherwise, it
/// will throw an exception
/// </summary>
/// <param name="BurnsUriParameterBuilder">This is a class that contains all the parameters that
/// can be passed to the API.</param>
/// <returns>
/// A BurnsDto object.
/// </returns>
        public BurnsDto Burns(BurnsUriParameterBuilder burnsUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(BurnsUri(burnsUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<BurnsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// It returns the burn amount for a given account.
/// </summary>
/// <param name="accountName">The name of the account to burn</param>
/// <returns>
/// A BurnDto object
/// </returns>
        public BurnDto Account(string accountName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(BurnUri(accountName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<BurnDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        private Uri BurnsUri() => new Uri($"{_requestUriBase}/burns");
        private Uri BurnsUri(BurnsUriParameterBuilder burnsUriParameterBuilder) => new Uri($"{_requestUriBase}/burns{burnsUriParameterBuilder.Build()}");
        private Uri BurnUri(string accountName) => new Uri($"{_requestUriBase}/burns/{accountName}");
    }
}
