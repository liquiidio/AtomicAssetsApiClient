﻿using System;
using System.Threading.Tasks;

namespace AtomicAssetsApiClient.Assets
{
    public class AssetsApi
    {
        private readonly string _requestUriBase;
        private readonly IHttpHandler _httpHander;
        internal AssetsApi(string baseUrl, IHttpHandler httpHandler)
        {
            _requestUriBase = baseUrl;
            _httpHander = httpHandler;
        }

        internal AssetsApi(string baseUrl) => _requestUriBase = baseUrl;

        /// <summary>
        /// This function will return a list of all the assets that are available for trading on the
        /// exchange
        /// </summary>
        /// <returns>
        /// A list of assets.
        /// </returns>
        public async Task<AssetsDto> Assets()
        {
            return await _httpHander.GetJsonAsync<AssetsDto>(AssetsUri().OriginalString);
        }

        /// <summary>
        /// This function will return a list of assets based on the parameters passed in
        /// </summary>
        /// <param name="AssetsUriParameterBuilder">This is a class that contains all the parameters
        /// that can be passed to the API.</param>
        /// <returns>
        /// A list of assets.
        /// </returns>
        public async Task<AssetsDto> Assets(AssetsUriParameterBuilder assetsUriParameterBuilder)
        {
            return await _httpHander.GetJsonAsync<AssetsDto>(AssetsUri(assetsUriParameterBuilder).OriginalString);
        }

        /// <summary>
        /// This function will return an AssetDto object from the API
        /// </summary>
        /// <param name="assetId">The id of the asset you want to retrieve.</param>
        /// <returns>
        /// An AssetDto object
        /// </returns>
        public async Task<AssetDto> Asset(string assetId)
        {
            return await _httpHander.GetJsonAsync<AssetDto>(AssetUri(assetId).OriginalString);
        }

        /// <summary>
        /// It returns the stats of an asset.
        /// </summary>
        /// <param name="assetId">The asset id of the asset you want to get the stats for.</param>
        /// <returns>
        /// A StatsDto object
        /// </returns>
        public async Task<StatsDto> AssetStats(string assetId)
        {
            return await _httpHander.GetJsonAsync<StatsDto>(AssetStatsUri(assetId).OriginalString);
        }

        /// <summary>
        /// It returns the logs of an asset.
        /// </summary>
        /// <param name="assetId">The asset id of the asset you want to get the logs for.</param>
        /// <returns>
        /// A list of logs for the asset.
        /// </returns>
        public async Task<LogsDto> AssetLogs(string assetId)
        {
            return await _httpHander.GetJsonAsync<LogsDto>(AssetLogsUri(assetId).OriginalString);
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
        public async Task<LogsDto> AssetLogs(string assetId, AssetsUriParameterBuilder assetsUriParameterBuilder)
        {
            return await _httpHander.GetJsonAsync<LogsDto>(AssetLogsUri(assetId, assetsUriParameterBuilder).OriginalString);
        }


        /// <summary>
        /// It returns a URI that points to the assets endpoint
        /// </summary>
        private Uri AssetsUri() => new Uri($"{_requestUriBase}/assets");

        /// <summary>
        /// It takes an `AssetsUriParameterBuilder` object as a parameter, and returns a `Uri` object
        /// that is the base URI for the `Assets` endpoint, with the parameters from the
        /// `AssetsUriParameterBuilder` object appended to it
        /// </summary>
        /// <param name="AssetsUriParameterBuilder">A class that builds the query string parameters for
        /// the assets endpoint.</param>
        private Uri AssetsUri(AssetsUriParameterBuilder assetsUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/assets{assetsUriParameterBuilder.Build()}");

        /// <summary>
        /// It takes an asset ID and returns a URI that can be used to request the asset from the API
        /// </summary>
        /// <param name="assetId">The ID of the asset you want to retrieve.</param>
        private Uri AssetUri(string assetId) => new Uri($"{_requestUriBase}/assets/{assetId}");
        /// <summary>
        /// > It returns a URI for the asset stats endpoint
        /// </summary>
        /// <param name="assetId">The asset ID of the asset you want to get stats for.</param>
        private Uri AssetStatsUri(string assetId) => new Uri($"{_requestUriBase}/assets/{assetId}/stats");
        /// <summary>
        /// It returns a URI for the logs of a specific asset
        /// </summary>
        /// <param name="assetId">The ID of the asset you want to get logs for.</param>
        private Uri AssetLogsUri(string assetId) => new Uri($"{_requestUriBase}/assets/{assetId}/logs");

        /// <summary>
        /// It takes an assetId and an AssetsUriParameterBuilder and returns a Uri
        /// </summary>
        /// <param name="assetId">The asset ID of the asset you want to get logs for.</param>
        /// <param name="AssetsUriParameterBuilder">This is a class that builds the query string
        /// parameters for the request.</param>
        private Uri AssetLogsUri(string assetId, AssetsUriParameterBuilder assetsUriParameterBuilder) =>
            new Uri($"{_requestUriBase}/assets/{assetId}/logs{assetsUriParameterBuilder.Build()}");
    }
}