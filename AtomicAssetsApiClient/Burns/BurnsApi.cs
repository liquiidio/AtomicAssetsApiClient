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
        /// This function will make a GET request to the Burns endpoint and return the response as a
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
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// This function will return a BurnsDto object if the API call is successful. Otherwise, it
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
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
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
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// > This function returns a Uri object that represents the Burns endpoint
        /// </summary>
        private Uri BurnsUri() => new Uri($"{_requestUriBase}/burns");

        /// <summary>
        /// It takes a BurnsUriParameterBuilder object and returns a Uri object.
        /// </summary>
        /// <param name="BurnsUriParameterBuilder">A class that builds the query string parameters for
        /// the URI.</param>
        private Uri BurnsUri(BurnsUriParameterBuilder burnsUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/burns{burnsUriParameterBuilder.Build()}");

        /// <summary>
        /// > This function returns a URI that can be used to burn a specific account
        /// </summary>
        /// <param name="accountName">The name of the account to burn.</param>
        private Uri BurnUri(string accountName) => new Uri($"{_requestUriBase}/burns/{accountName}");
    }
}