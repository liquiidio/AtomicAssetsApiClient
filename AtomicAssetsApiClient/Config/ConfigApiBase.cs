using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Core.Config
{
    public class ConfigApiBase
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHandler;

        protected ConfigApiBase(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHandler = httpHandler;
        }

        public async Task<ConfigDto> Config()
        {
            return await _httpHandler.GetJsonAsync<ConfigDto>(ConfigUri().OriginalString);
        }

        private Uri ConfigUri() => new Uri($"{_requestUriBase}/config");
    }
}