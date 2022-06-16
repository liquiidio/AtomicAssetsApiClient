using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Offers
{
    public class OffersApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal OffersApi(string baseUrl) => _requestUriBase = baseUrl;

/// <summary>
/// > This function will make a GET request to the `Offers` endpoint and return the response as
/// a `OffersDto` object
/// </summary>
/// <returns>
/// A list of offers
/// </returns>
        public OffersDto Offers()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(OffersUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<OffersDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// It takes a `OffersUriParameterBuilder` object as a parameter, builds a `HttpRequestMessage`
/// object, sends it to the API, and returns the response as a `OffersDto` object
/// </summary>
/// <param name="OffersUriParameterBuilder">This is a class that contains all the parameters
/// that can be passed to the API.</param>
/// <returns>
/// A list of offers.
/// </returns>
        public OffersDto Offers(OffersUriParameterBuilder offersUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(OffersUri(offersUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<OffersDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > This function will return an OfferDto object if the API call is successful. Otherwise, it
/// will throw an exception
/// </summary>
/// <param name="offerId">The id of the offer you want to retrieve.</param>
/// <returns>
/// A single offer
/// </returns>
        public OfferDto Offer(string offerId)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(OfferUri(offerId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<OfferDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// This function will return a list of logs for a specific offer
/// </summary>
/// <param name="offerId">The offer ID of the offer you want to get the logs for.</param>
/// <returns>
/// A list of logs for the offer.
/// </returns>
        public LogsDto OfferLogs(string offerId)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(OfferLogsUri(offerId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// This function returns a list of logs for a specific offer
/// </summary>
/// <param name="offerId">The offer id of the offer you want to get the logs for.</param>
/// <param name="OffersUriParameterBuilder">This is a class that contains all the parameters that
/// can be passed to the API.</param>
/// <returns>
/// A LogsDto object
/// </returns>
        public LogsDto OfferLogs(string offerId, OffersUriParameterBuilder  schemasUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(OfferLogsUri(offerId, schemasUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        private Uri OffersUri() => new Uri($"{_requestUriBase}/offers");
        private Uri OffersUri(OffersUriParameterBuilder  offersUriParameterBuilder) => new Uri($"{_requestUriBase}/offers{offersUriParameterBuilder.Build()}");
        private Uri OfferUri(string offerId) => new Uri($"{_requestUriBase}/offers/{offerId}");
        private Uri OfferLogsUri(string offerId) => new Uri($"{_requestUriBase}/offers/{offerId}/logs");
        private Uri OfferLogsUri(string offerId, OffersUriParameterBuilder  offersUriParameterBuilder) => new Uri($"{_requestUriBase}/offers/{offerId}/logs{offersUriParameterBuilder.Build()}");
    }
}