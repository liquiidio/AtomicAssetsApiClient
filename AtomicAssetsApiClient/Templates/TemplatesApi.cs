using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Templates
{
    public class TemplatesApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHandler;

        internal TemplatesApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHandler = httpHandler;
        }

        public async Task<TemplatesDto> Templates()
        /// <summary>
        /// This function will return a list of templates that are available to the user
        /// </summary>
        /// <returns>
        /// A TemplatesDto object
        /// </returns>
        public TemplatesDto Templates()
        {
            return await _httpHandler.GetJsonAsync<TemplatesDto>(TemplatesUri().OriginalString);
        }

        public async Task<TemplatesDto> Templates(TemplatesUriParameterBuilder templatesUriParameterBuilder)
        /// <summary>
        /// This function will return a TemplatesDto object that contains a list of templates that match
        /// the criteria specified in the TemplatesUriParameterBuilder object
        /// </summary>
        /// <param name="TemplatesUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the API.</param>
        /// <returns>
        /// A TemplatesDto object.
        /// </returns>
        public TemplatesDto Templates(TemplatesUriParameterBuilder templatesUriParameterBuilder)
        {
            return await _httpHandler.GetJsonAsync<TemplatesDto>(TemplatesUri(templatesUriParameterBuilder).OriginalString);
        }

        public async Task<TemplateDto> Template(string collectionName, string templateId)
        /// <summary>
        /// This function will return a TemplateDto object from the API
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to create the template
        /// in.</param>
        /// <param name="templateId">The id of the template you want to retrieve.</param>
        /// <returns>
        /// A TemplateDto object
        /// </returns>
        public TemplateDto Template(string collectionName, string templateId)
        {
            return await _httpHandler.GetJsonAsync<TemplateDto>(TemplateUri(collectionName, templateId).OriginalString);
        }

        public async Task<StatsDto> TemplateStats(string collectionName, string templateId)
        /// <summary>
        /// This function will return a StatsDto object that contains the number of documents that have
        /// been indexed using the specified template
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the stats
        /// for.</param>
        /// <param name="templateId">The id of the template you want to get stats for.</param>
        /// <returns>
        /// A StatsDto object
        /// </returns>
        public StatsDto TemplateStats(string collectionName, string templateId)
        {
            return await _httpHandler.GetJsonAsync<StatsDto>(TemplateStatsUri(collectionName, templateId).OriginalString);
        }

        public async Task<LogsDto> TemplateLogs(string collectionName, string templateId)
        /// <summary>
        /// This function returns a list of logs for a specific template
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs for.</param>
        /// <param name="templateId">The id of the template you want to get the logs for.</param>
        /// <returns>
        /// A list of logs for a specific template.
        /// </returns>
        public LogsDto TemplateLogs(string collectionName, string templateId)
        {
            return await _httpHandler.GetJsonAsync<LogsDto>(TemplateLogsUri(collectionName, templateId).OriginalString);
        }

        public async Task<LogsDto> TemplateLogs(string collectionName, string templateId, TemplatesUriParameterBuilder templatesUriParameterBuilder)
        /// <summary>
        /// This function returns a list of logs for a specific template
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs
        /// for.</param>
        /// <param name="templateId">The id of the template you want to get the logs for.</param>
        /// <param name="TemplatesUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the API.</param>
        /// <returns>
        /// A LogsDto object
        /// </returns>
        public LogsDto TemplateLogs(string collectionName, string templateId,
            TemplatesUriParameterBuilder templatesUriParameterBuilder)
        {
            return await _httpHandler.GetJsonAsync<LogsDto>(TemplateLogsUri(collectionName, templateId, templatesUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// > It returns a new `Uri` object that is the base URI for the templates endpoint
        /// </summary>
        private Uri TemplatesUri() => new Uri($"{_requestUriBase}/templates");

        /// <summary>
        /// It takes a `TemplatesUriParameterBuilder` object as a parameter and returns a `Uri` object
        /// </summary>
        /// <param name="TemplatesUriParameterBuilder">A class that builds the query string parameters
        /// for the templates endpoint.</param>
        private Uri TemplatesUri(TemplatesUriParameterBuilder templatessUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/templates{templatessUriParameterBuilder.Build()}");

        /// <summary>
        /// > It returns a URI for a specific template in a specific collection
        /// </summary>
        /// <param name="collectionName">The name of the collection that the template belongs
        /// to.</param>
        /// <param name="templateId">The name of the template you want to use.</param>
        private Uri TemplateUri(string collectionName, string templateId) =>
            new Uri($"{_requestUriBase}/templates/{collectionName}/{templateId}");

        /// <summary>
        /// > This function returns a Uri that can be used to get the stats for a template
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to use.</param>
        /// <param name="templateId">The template ID of the template you want to get stats for.</param>
        private Uri TemplateStatsUri(string collectionName, string templateId) =>
            new Uri($"{_requestUriBase}/templates/{collectionName}/{templateId}/stats");

        /// <summary>
        /// > This function returns a Uri for the logs of a template
        /// </summary>
        /// <param name="collectionName">The name of the collection that the template belongs to.</param>
        /// <param name="templateId">The ID of the template you want to get logs for.</param>
        private Uri TemplateLogsUri(string collectionName, string templateId) =>
            new Uri($"{_requestUriBase}/templates/{collectionName}/{templateId}/logs");

        /// <summary>
        /// > This function returns a Uri for the logs of a template
        /// </summary>
        /// <param name="collectionName">The name of the collection that the template belongs
        /// to.</param>
        /// <param name="templateId">The id of the template you want to get logs for.</param>
        /// <param name="TemplatesUriParameterBuilder">This is a class that builds the query string
        /// parameters for the request.</param>
        private Uri TemplateLogsUri(string collectionName, string templateId,
            TemplatesUriParameterBuilder templatesUriParameterBuilder) => new Uri(
            $"{_requestUriBase}/templates/{collectionName}/{templateId}/logs{templatesUriParameterBuilder.Build()}");
    }
}