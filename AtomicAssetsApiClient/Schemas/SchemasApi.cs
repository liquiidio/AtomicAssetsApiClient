using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Schemas
{
    public class SchemasApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHandler;

        internal SchemasApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHandler = httpHandler;
        }

        /// <summary>
        /// This function will return a `SchemasDto` object that contains a list of all the schemas
        /// that are available in the API
        /// </summary>
        /// <returns>
        /// A SchemasDto object.
        /// </returns>
        public async Task<SchemasDto> Schemas()
        {
            return await _httpHandler.GetJsonAsync<SchemasDto>(SchemasUri().OriginalString);
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
        public async Task<SchemasDto> Schemas(SchemasUriParameterBuilder schemasUriParameterBuilder)
        {
            return await _httpHandler.GetJsonAsync<SchemasDto>(SchemasUri(schemasUriParameterBuilder).OriginalString);
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
        public async Task<SchemaDto> Schema(string collectionName, string schemaName)
        {
            return await _httpHandler.GetJsonAsync<SchemaDto>(SchemaUri(collectionName, schemaName).OriginalString);
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
        public async Task<StatsDto> SchemaStats(string collectionName, string schemaName)
        {
            return await _httpHandler.GetJsonAsync<StatsDto>(SchemaStatsUri(collectionName, schemaName).OriginalString);
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
        public async Task<LogsDto> SchemaLogs(string collectionName, string schemaName)
        {
            return await _httpHandler.GetJsonAsync<LogsDto>(SchemaLogsUri(collectionName, schemaName).OriginalString);
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
        public async Task<LogsDto> SchemaLogs(string collectionName, string schemaName, SchemasUriParameterBuilder schemasUriParameterBuilder)

        {
            return await _httpHandler.GetJsonAsync<LogsDto>(SchemaLogsUri(collectionName, schemaName, schemasUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// It returns a URI that points to the schemas endpoint
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
        /// <param name="collectionName">The name of the collection you want to create the schema
        /// in.</param>
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
        /// It returns a URI for the schema logs endpoint
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