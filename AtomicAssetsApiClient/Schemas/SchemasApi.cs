using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Schemas
{
    public class SchemasApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal SchemasApi(string baseUrl) => _requestUriBase = baseUrl;

        /// <summary>
        /// This function will return a `SchemasDto` object that contains a list of all the schemas
        /// that are available in the API
        /// </summary>
        /// <returns>
        /// A SchemasDto object.
        /// </returns>
        public SchemasDto Schemas()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(SchemasUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<SchemasDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// This function will return a list of schemas that match the criteria specified in the
        /// `SchemasUriParameterBuilder` object
        /// </summary>
        /// <param name="SchemasUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the API.</param>
        /// <returns>
        /// A list of schemas.
        /// </returns>
        public SchemasDto Schemas(SchemasUriParameterBuilder schemasUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(SchemasUri(schemasUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<SchemasDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// This function will return a schema object for the specified collection and schema name
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the schema
        /// for.</param>
        /// <param name="schemaName">The name of the schema you want to retrieve.</param>
        /// <returns>
        /// A SchemaDto object.
        /// </returns>
        public SchemaDto Schema(string collectionName, string schemaName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(SchemaUri(collectionName, schemaName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<SchemaDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// It returns the stats of a schema.
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the stats
        /// for.</param>
        /// <param name="schemaName">The name of the schema you want to get stats for.</param>
        /// <returns>
        /// A StatsDto object
        /// </returns>
        public StatsDto SchemaStats(string collectionName, string schemaName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(SchemaStatsUri(collectionName, schemaName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<StatsDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// This function returns a list of logs for a specific schema
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs
        /// for.</param>
        /// <param name="schemaName">The name of the schema you want to get logs for.</param>
        /// <returns>
        /// A list of logs for the schema.
        /// </returns>
        public LogsDto SchemaLogs(string collectionName, string schemaName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(SchemaLogsUri(collectionName, schemaName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        /// <summary>
        /// This function returns a list of logs for a specific schema
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the schema logs
        /// for.</param>
        /// <param name="schemaName">The name of the schema you want to get the logs for.</param>
        /// <param name="SchemasUriParameterBuilder">This is a class that contains the parameters that
        /// can be passed to the API.</param>
        /// <returns>
        /// A LogsDto object.
        /// </returns>
        public LogsDto SchemaLogs(string collectionName, string schemaName,
            SchemasUriParameterBuilder schemasUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder
                .GetRequest(SchemaLogsUri(collectionName, schemaName, schemasUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException(
                $"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

       /// <summary>
       /// > It returns a `Uri` object that represents the `/schemas` endpoint of the `_requestUriBase`
       /// property
       /// </summary>
        private Uri SchemasUri() => new Uri($"{_requestUriBase}/schemas");

        /// <summary>
        /// It takes a `SchemasUriParameterBuilder` object as a parameter, and returns a `Uri` object.
        /// </summary>
        /// <param name="SchemasUriParameterBuilder">A class that builds the query string parameters for
        /// the schemas endpoint.</param>
        private Uri SchemasUri(SchemasUriParameterBuilder schemasUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/schemas{schemasUriParameterBuilder.Build()}");

        /// <summary>
        /// > It returns a URI for a specific schema in a specific collection
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to create a schema
        /// for.</param>
        /// <param name="schemaName">The name of the schema to be created.</param>
        private Uri SchemaUri(string collectionName, string schemaName) =>
            new Uri($"{_requestUriBase}/schemas/{collectionName}/{schemaName}");

        /// <summary>
        /// It returns a URI that points to the stats for a specific schema in a specific collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the schema stats
        /// for.</param>
        /// <param name="schemaName">The name of the schema.</param>
        private Uri SchemaStatsUri(string collectionName, string schemaName) =>
            new Uri($"{_requestUriBase}/schemas/{collectionName}/{schemaName}/stats");

        /// <summary>
        /// > This function returns a URI for the schema logs endpoint
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to create a schema
        /// for.</param>
        /// <param name="schemaName">The name of the schema.</param>
        private Uri SchemaLogsUri(string collectionName, string schemaName) =>
            new Uri($"{_requestUriBase}/schemas/{collectionName}/{schemaName}/logs");

        /// <summary>
        /// It returns a URI for the logs of a schema
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="SchemasUriParameterBuilder">This is a class that helps you build the query
        /// parameters for the request.</param>
        private Uri SchemaLogsUri(string collectionName, string schemaName,
            SchemasUriParameterBuilder schemasUriParameterBuilder) => new Uri(
            $"{_requestUriBase}/schemas/{collectionName}/{schemaName}/logs{schemasUriParameterBuilder.Build()}");
    }
}