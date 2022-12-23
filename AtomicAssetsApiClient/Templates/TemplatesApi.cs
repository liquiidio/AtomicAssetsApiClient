using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Templates
{
    public class TemplatesApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal TemplatesApi(string baseUrl) => _requestUriBase = baseUrl;

        /// <summary>
        /// This function will return a list of templates that are available to the user
        /// </summary>
        /// <returns>
        /// A TemplatesDto object
        /// </returns>
        public TemplatesDto Templates()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(TemplatesUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<TemplatesDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

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
            var apiRequest = HttpRequestBuilder.GetRequest(TemplatesUri(templatesUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<TemplatesDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

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
            var apiRequest = HttpRequestBuilder.GetRequest(TemplateUri(collectionName, templateId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<TemplateDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

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
            var apiRequest = HttpRequestBuilder.GetRequest(TemplateStatsUri(collectionName, templateId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<StatsDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

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
            var apiRequest = HttpRequestBuilder.GetRequest(TemplateLogsUri(collectionName, templateId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

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
            var apiRequest = HttpRequestBuilder
                .GetRequest(TemplateLogsUri(collectionName, templateId, templatesUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
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