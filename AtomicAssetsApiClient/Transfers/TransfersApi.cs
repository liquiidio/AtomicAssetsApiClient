using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Transfers
{
    public class TransfersApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal TransfersApi(string baseUrl) => _requestUriBase = baseUrl;

        /// <summary>
        /// It returns a list of transfers.
        /// </summary>
        /// <returns>
        /// A list of transfers.
        /// </returns>
                public TransfersDto Transfers()
                {
                    var apiRequest = HttpRequestBuilder.GetRequest(TransfersUri()).Build();
                    var apiResponse = Client.SendAsync(apiRequest).Result;
                    if (apiResponse.IsSuccessStatusCode)
                        return apiResponse.ContentAs<TransfersDto>();
                    throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
                }

        /// <summary>
        /// It returns a list of transfers.
        /// </summary>
        /// <param name="TransfersUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the API.</param>
        /// <returns>
        /// A TransfersDto object.
        /// </returns>
        public TransfersDto Transfers(TransfersUriParameterBuilder transfersUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(TransfersUri(transfersUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<TransfersDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// It returns a URI that points to the transfers endpoint
        /// </summary>
        private Uri TransfersUri() => new Uri($"{_requestUriBase}/transfers");
        
        /// <summary>
        /// It takes a `TransfersUriParameterBuilder` object and returns a `Uri` object
        /// </summary>
        /// <param name="TransfersUriParameterBuilder">A class that builds the query string parameters
        /// for the transfers endpoint.</param>
        private Uri TransfersUri(TransfersUriParameterBuilder transfersUriParameterBuilder) => new Uri($"{_requestUriBase}/transfers{transfersUriParameterBuilder.Build()}");
    }
}