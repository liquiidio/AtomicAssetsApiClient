using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Collections
{
    public class CollectionsApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal CollectionsApi(string baseUrl) => _requestUriBase = baseUrl;

/// <summary>
/// It returns a list of all the collections in the database.
/// </summary>
/// <returns>
/// A list of collections
/// </returns>
        public CollectionsDto Collections()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(CollectionsUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<CollectionsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
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

        public CollectionsDto Collections(CollectionsUriParameterBuilder collectionsUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(CollectionsUri(collectionsUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<CollectionsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// This function will return a collection object from the API
/// </summary>
/// <param name="collectionName">The name of the collection you want to retrieve.</param>
/// <returns>
/// A collection of documents.
/// </returns>
        public CollectionDto Collection(string collectionName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(CollectionUri(collectionName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<CollectionDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }
 
/// <summary>
/// This function will return a StatsDto object that contains the stats for the collection
/// specified in the collectionName parameter
/// </summary>
/// <param name="collectionName">The name of the collection you want to get stats for.</param>
/// <returns>
/// A StatsDto object
/// </returns>
        public StatsDto CollectionStats(string collectionName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(CollectionStatsUri(collectionName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<StatsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// This function will return a list of logs for a given collection
/// </summary>
/// <param name="collectionName">The name of the collection you want to get the logs for.</param>
/// <returns>
/// A LogsDto object
/// </returns>
        public LogsDto CollectionLogs(string collectionName)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(CollectionLogsUri(collectionName)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
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
        public LogsDto CollectionLogs(string collectionName, CollectionsUriParameterBuilder collectionsUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(CollectionLogsUri(collectionName, collectionsUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

        private Uri CollectionsUri() => new Uri($"{_requestUriBase}/collections");
        private Uri CollectionsUri(CollectionsUriParameterBuilder collectionsUriParameterBuilder) => new Uri($"{_requestUriBase}/collections{collectionsUriParameterBuilder.Build()}");
        private Uri CollectionUri(string collectionName) => new Uri($"{_requestUriBase}/collections/{collectionName}");
        private Uri CollectionStatsUri(string collectionName) => new Uri($"{_requestUriBase}/collections/{collectionName}/stats");
        private Uri CollectionLogsUri(string collectionName) => new Uri($"{_requestUriBase}/collections/{collectionName}/logs");
        private Uri CollectionLogsUri(string collectionName, CollectionsUriParameterBuilder collectionsUriParameterBuilder) => new Uri($"{_requestUriBase}/collections/{collectionName}/logs{collectionsUriParameterBuilder.Build()}");
    }
}