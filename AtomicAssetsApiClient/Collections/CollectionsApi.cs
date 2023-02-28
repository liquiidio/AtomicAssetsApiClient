using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Collections
{
    public class CollectionsApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHander;

        internal CollectionsApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHander = httpHandler;
        }

        /// <summary>
        /// It returns a list of all the collections in the database.
        /// </summary>
        /// <returns>
        /// A list of collections
        /// </returns>
        public async Task<CollectionsDto> Collections()
        {
            return await _httpHander.GetJsonAsync<CollectionsDto>(CollectionsUri().OriginalString);
        }

        /// <summary>
        /// It takes a `CollectionsUriParameterBuilder` object as a parameter, builds an `HttpRequestMessage`
        /// object, sends it to the API, and returns a `CollectionsDto` object.
        /// </summary>
        /// <param name="CollectionsUriParameterBuilder">This is a class that contains all the parameters that
        /// can be passed to the API.</param>
        /// <returns>
        /// A collection of collections.
        /// </returns>
        public async Task<CollectionsDto> Collections(CollectionsUriParameterBuilder collectionsUriParameterBuilder)
        {
            return await _httpHander.GetJsonAsync<CollectionsDto>(CollectionsUri(collectionsUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// This function will return a collection object from the API
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to retrieve.</param>
        /// <returns>
        /// A collection of documents.
        /// </returns>
        public async Task<CollectionDto> Collection(string collectionName)
        {
            return await _httpHander.GetJsonAsync<CollectionDto>(CollectionUri(collectionName).OriginalString);
        }


        /// <summary>
        /// This function will return a StatsDto object that contains the stats for the collection
        /// specified in the collectionName parameter
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get stats for.</param>
        /// <returns>
        /// A StatsDto object
        /// </returns>
        public async Task<StatsDto> CollectionStats(string collectionName)
        {
            return await _httpHander.GetJsonAsync<StatsDto>(CollectionStatsUri(collectionName).OriginalString);
        }

        /// <summary>
        /// This function will return a list of logs for a given collection
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs for.</param>
        /// <returns>
        /// A LogsDto object
        /// </returns>
        public async Task<LogsDto> CollectionLogs(string collectionName)
        {
            return await _httpHander.GetJsonAsync<LogsDto>(CollectionLogsUri(collectionName).OriginalString);
        }

        /// <summary>
        /// This function returns a list of logs for a given collection
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs
        /// for.</param>
        /// <param name="CollectionsUriParameterBuilder">This is a class that allows you to build the
        /// query string parameters for the request.</param>
        /// <returns>
        /// A LogsDto object
        /// </returns>
        public async Task<LogsDto> CollectionLogs(string collectionName, CollectionsUriParameterBuilder collectionsUriParameterBuilder)
        {
            return await _httpHander.GetJsonAsync<LogsDto>(CollectionLogsUri(collectionName, collectionsUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// It returns a Uri object that represents the URL for the collections endpoint
        /// </summary>
        private Uri CollectionsUri() => new Uri($"{_requestUriBase}/collections");

        /// <summary>
        /// It takes a `CollectionsUriParameterBuilder` object as a parameter and returns a `Uri`
        /// object.
        /// </summary>
        /// <param name="CollectionsUriParameterBuilder">A class that builds the query string parameters
        /// for the collections endpoint.</param>
        private Uri CollectionsUri(CollectionsUriParameterBuilder collectionsUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/collections{collectionsUriParameterBuilder.Build()}");

        /// <summary>
        /// Given a collection name, return a Uri object that represents the collection's endpoint.
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to query.</param>
        private Uri CollectionUri(string collectionName) => new Uri($"{_requestUriBase}/collections/{collectionName}");

        /// <summary>
        /// It returns a URI that points to the stats endpoint for a given collection
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get stats for.</param>
        private Uri CollectionStatsUri(string collectionName) =>
            new Uri($"{_requestUriBase}/collections/{collectionName}/stats");

        /// <summary>
        /// It returns a URI for the collection logs endpoint
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs
        /// for.</param>
        private Uri CollectionLogsUri(string collectionName) =>
            new Uri($"{_requestUriBase}/collections/{collectionName}/logs");

        /// <summary>
        /// It returns a Uri object that represents the URL for the collection logs endpoint
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to get the logs
        /// for.</param>
        /// <param name="CollectionsUriParameterBuilder">This is a class that builds the query
        /// parameters for the request.</param>
        private Uri CollectionLogsUri(string collectionName,
            CollectionsUriParameterBuilder collectionsUriParameterBuilder) => new Uri(
            $"{_requestUriBase}/collections/{collectionName}/logs{collectionsUriParameterBuilder.Build()}");
    }
}