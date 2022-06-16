using System;
using System.Net.Http;
using AtomicAssetsApiClient.Core;

namespace AtomicAssetsApiClient.Assets
{
    public class AssetsApi
    {
        private readonly string _requestUriBase;
        private static readonly HttpClient Client = new HttpClient();

        internal AssetsApi(string baseUrl) => _requestUriBase = baseUrl;

/// <summary>
/// > This function will return a list of all the assets that are available for trading on the
/// exchange
/// </summary>
/// <returns>
/// A list of assets.
/// </returns>
        public AssetsDto Assets()
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AssetsUri()).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AssetsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > This function will return a list of assets based on the parameters passed in
/// </summary>
/// <param name="AssetsUriParameterBuilder">This is a class that contains all the parameters
/// that can be passed to the API.</param>
/// <returns>
/// A list of assets.
/// </returns>
        public AssetsDto Assets(AssetsUriParameterBuilder assetsUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AssetsUri(assetsUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AssetsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > This function will return an AssetDto object from the API
/// </summary>
/// <param name="assetId">The id of the asset you want to retrieve.</param>
/// <returns>
/// An AssetDto object
/// </returns>
        public AssetDto Asset(string assetId)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AssetUri(assetId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<AssetDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// It returns the stats of an asset.
/// </summary>
/// <param name="assetId">The asset id of the asset you want to get the stats for.</param>
/// <returns>
/// A StatsDto object
/// </returns>
        public StatsDto AssetStats(string assetId)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AssetStatsUri(assetId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<StatsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// It returns the logs of an asset.
/// </summary>
/// <param name="assetId">The asset id of the asset you want to get the logs for.</param>
/// <returns>
/// A list of logs for the asset.
/// </returns>
        public LogsDto AssetLogs(string assetId)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AssetLogsUri(assetId)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// This function returns a list of logs for a given asset
/// </summary>
/// <param name="assetId">The id of the asset you want to get logs for.</param>
/// <param name="AssetsUriParameterBuilder">This is a class that contains all the parameters that
/// can be passed to the API.</param>
/// <returns>
/// A list of logs for the asset.
/// </returns>
        public LogsDto AssetLogs(string assetId, AssetsUriParameterBuilder assetsUriParameterBuilder)
        {
            var apiRequest = HttpRequestBuilder.GetRequest(AssetLogsUri(assetId, assetsUriParameterBuilder)).Build();
            var apiResponse = Client.SendAsync(apiRequest).Result;
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.ContentAs<LogsDto>();
            throw new ArgumentException($"An exception has occurred. Status Code: {apiResponse.StatusCode} Error: {apiResponse.Content.ReadAsStringAsync().Result}");
        }

/// <summary>
/// > The function takes a string and returns a Uri
/// </summary>
        private Uri AssetsUri() => new Uri($"{_requestUriBase}/assets");
        private Uri AssetsUri(AssetsUriParameterBuilder assetsUriParameterBuilder) => new Uri($"{_requestUriBase}/assets{assetsUriParameterBuilder.Build()}");
        private Uri AssetUri(string assetId) => new Uri($"{_requestUriBase}/assets/{assetId}");
        private Uri AssetStatsUri(string assetId) => new Uri($"{_requestUriBase}/assets/{assetId}/stats");
        private Uri AssetLogsUri(string assetId) => new Uri($"{_requestUriBase}/assets/{assetId}/logs");
        private Uri AssetLogsUri(string assetId, AssetsUriParameterBuilder assetsUriParameterBuilder) => new Uri($"{_requestUriBase}/assets/{assetId}/logs{assetsUriParameterBuilder.Build()}");
    }
}