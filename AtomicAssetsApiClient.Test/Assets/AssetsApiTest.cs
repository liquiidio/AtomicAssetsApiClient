using System.Linq;
using AtomicAssetsApiClient.Assets;
using FluentAssertions;
using NUnit.Framework;

namespace AtomicAssetsApiClient.Test.Assets
{
    [TestFixture]
    public class AssetsApiTest
    {
        [Test]
        public void Assets()
        {
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets().Should().BeOfType<AssetsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets().Data.Should().BeOfType<AssetsDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets(new AssetsUriParameterBuilder().WithLimit(1)).Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.AssetsApi.Assets(new AssetsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).Should().BeOfType<AssetsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Assets(new AssetsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).Data.Should().BeOfType<AssetsDto.DataDto[]>();
        }

        [Test]
        public void Asset()
        {
            var assetIdToFind = AtomicAssetsApiFactory.Version1.AssetsApi.Assets().Data.First().AssetId;
            AtomicAssetsApiFactory.Version1.AssetsApi.Asset(assetIdToFind).Should().BeOfType<AssetDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.Asset(assetIdToFind).Data.Should().BeOfType<AssetDto.DataDto>();
        }

        [Test]
        [Ignore("Test Ignored")]
        public void AssetStats()
        {
            var assetIdToFind = AtomicAssetsApiFactory.Version1.AssetsApi.Assets().Data.First().AssetId;
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetStats(assetIdToFind).Should().BeOfType<StatsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetStats(assetIdToFind).Data.Should().BeOfType<StatsDto.DataDto>();
        }

        [Test]
        [Ignore("Test Ignored")]
        public void AssetLogs()
        {
            var assetIdToFind = AtomicAssetsApiFactory.Version1.AssetsApi.Assets().Data.First().AssetId;
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetLogs(assetIdToFind).Should().BeOfType<LogsDto>();
            AtomicAssetsApiFactory.Version1.AssetsApi.AssetLogs(assetIdToFind).Data.Should().BeOfType<LogsDto.DataDto>();
        }
    }
}