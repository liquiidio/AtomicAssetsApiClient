using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Transfers
{
    public class TransfersApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHandler;

        internal TransfersApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHandler = httpHandler;
        }

        /// <summary>
        /// It returns a list of transfers.
        /// </summary>
        /// <returns>
        /// A list of transfers.
        /// </returns>
        public async Task<TransfersDto> Transfers()
        {
            return await _httpHandler.GetJsonAsync<TransfersDto>(TransfersUri().OriginalString);
        }


        /// <summary>
        /// It returns a list of transfers.
        /// </summary>
        /// <param name="TransfersUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the API.</param>
        /// <returns>
        /// A TransfersDto object.
        /// </returns>
        public async Task<TransfersDto> Transfers(TransfersUriParameterBuilder transfersUriParameterBuilder)
        {
            return await _httpHandler.GetJsonAsync<TransfersDto>(TransfersUri(transfersUriParameterBuilder).OriginalString);
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