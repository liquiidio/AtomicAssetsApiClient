using System.Linq;
using AtomicAssetsApiClient.Assets;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Assets
{
    [TestClass]
    public class AssetsApiTest
    {
        [TestMethod]
        public void Assets()
        {
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets().GetAwaiter().GetResult().Should().BeOfType<AssetsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets().GetAwaiter().GetResult().Data.Should().BeOfType<AssetsDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets(new AssetsUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.AssetsApi.Assets(new AssetsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<AssetsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets(new AssetsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<AssetsDto.DataDto[]>();
        }

        [TestMethod]
        public void Asset()
        {
            var assetIdToFind = AtomicAssetsApiFactory.Version1.AssetsApi.Assets().GetAwaiter().GetResult().Data.First().AssetId;
            AtomicAssetsApiFactory.Version1.AssetsApi.Asset(assetIdToFind).GetAwaiter().GetResult().Should().BeOfType<AssetDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Asset(assetIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<AssetDto.DataDto>();
        }

        [TestMethod]
        [Ignore("Test Ignored, throws ApiException.")]
        public void AssetStats()
        {
            var assetIdToFind = AtomicAssetsApiFactory.Version1.AssetsApi.Assets().GetAwaiter().GetResult().Data.First().AssetId;
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetStats(assetIdToFind).GetAwaiter().GetResult().Should().BeOfType<StatsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetStats(assetIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<StatsDto.DataDto>();
        }

        [TestMethod]
        public void AssetLogs()
        {
            var assetIdToFind = AtomicAssetsApiFactory.Version1.AssetsApi.Assets().GetAwaiter().GetResult().Data.First().AssetId;
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetLogs(assetIdToFind).GetAwaiter().GetResult().Should().BeOfType<LogsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetLogs(assetIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<LogsDto.DataDto[]>();
        }
    }
}