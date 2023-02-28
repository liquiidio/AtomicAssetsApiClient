using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Offers
{
    public class OffersApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHandler;

        internal OffersApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHandler = httpHandler;
        }

        public async Task<OffersDto> Offers()
        /// <summary>
        /// This function will make a GET request to the `Offers` endpoint and return the response as
        /// a `OffersDto` object
        /// </summary>
        /// <returns>
        /// A list of offers
        /// </returns>
        public OffersDto Offers()
        {
            return await _httpHandler.GetJsonAsync<OffersDto>(OffersUri().OriginalString);
        }

        public async Task<OffersDto> Offers(OffersUriParameterBuilder offersUriParameterBuilder)
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
            return await _httpHandler.GetJsonAsync<OffersDto>(OffersUri(offersUriParameterBuilder).OriginalString);
        }

        public async Task<OfferDto> Offer(string offerId)
        /// <summary>
        /// This function will return an OfferDto object if the API call is successful. Otherwise, it
        /// will throw an exception
        /// </summary>
        /// <param name="offerId">The id of the offer you want to retrieve.</param>
        /// <returns>
        /// A single offer
        /// </returns>
        public OfferDto Offer(string offerId)
        {
            return await _httpHandler.GetJsonAsync<OfferDto>(OfferUri(offerId).OriginalString);
        }

        public async Task<LogsDto> OfferLogs(string offerId)
        /// <summary>
        /// This function will return a list of logs for a specific offer
        /// </summary>
        /// <param name="offerId">The offer ID of the offer you want to get the logs for.</param>
        /// <returns>
        /// A list of logs for the offer.
        /// </returns>
        public LogsDto OfferLogs(string offerId)
        {
            return await _httpHandler.GetJsonAsync<LogsDto>(OfferLogsUri(offerId).OriginalString);
        }

        public async Task<LogsDto> OfferLogs(string offerId, OffersUriParameterBuilder  schemasUriParameterBuilder)
        /// <summary>
        /// This function returns a list of logs for a specific offer
        /// </summary>
        /// <param name="offerId">The offer id of the offer you want to get the logs for.</param>
        /// <param name="OffersUriParameterBuilder">This is a class that contains all the parameters that
        /// can be passed to the API.</param>
        /// <returns>
        /// A LogsDto object
        /// </returns>
        public LogsDto OfferLogs(string offerId, OffersUriParameterBuilder schemasUriParameterBuilder)
        {
            return await _httpHandler.GetJsonAsync<LogsDto>(OfferLogsUri(offerId, schemasUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// > It returns a new `Uri` object that is built from the `_requestUriBase` field and the
        /// `/offers` path
        /// </summary>
        private Uri OffersUri() => new Uri($"{_requestUriBase}/offers");

        /// <summary>
        /// It takes a `OffersUriParameterBuilder` object as a parameter and returns a `Uri` object.
        /// </summary>
        /// <param name="OffersUriParameterBuilder">A class that builds the query string parameters for
        /// the request.</param>
        private Uri OffersUri(OffersUriParameterBuilder offersUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/offers{offersUriParameterBuilder.Build()}");

        /// <summary>
        /// It takes an offer ID and returns a URI
        /// </summary>
        /// <param name="offerId">The offer ID of the offer you want to get.</param>
        private Uri OfferUri(string offerId) => new Uri($"{_requestUriBase}/offers/{offerId}");
        /// <summary>
        /// > It returns a URI for the offer logs endpoint
        /// </summary>
        /// <param name="offerId">The ID of the offer you want to get logs for.</param>
        private Uri OfferLogsUri(string offerId) => new Uri($"{_requestUriBase}/offers/{offerId}/logs");

        /// <summary>
        /// It returns a URI for the offer logs endpoint
        /// </summary>
        /// <param name="offerId">The offer ID</param>
        /// <param name="OffersUriParameterBuilder">This is a class that builds the query string
        /// parameters for the request.</param>
        private Uri OfferLogsUri(string offerId, OffersUriParameterBuilder offersUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/offers/{offerId}/logs{offersUriParameterBuilder.Build()}");
    }
}