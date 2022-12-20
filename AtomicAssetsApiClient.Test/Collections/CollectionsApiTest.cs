using System.Linq;
using AtomicAssetsApiClient.Collections;
using FluentAssertions;
using NUnit.Framework;


namespace AtomicAssetsApiClient.Test.Collections
{
    [TestFixture]
    public class CollectionsApiTest
    {
        [Test]
        public void Collections()
        {
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Should().BeOfType<CollectionsDto>();
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Data.Should().BeOfType<CollectionsDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collections(new CollectionsUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.CollectionsApi.Collections(new CollectionsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<CollectionsDto>();
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collections(new CollectionsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<CollectionsDto.DataDto[]>();
        }

        [Test]
        public void Collection()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Data.First().CollectionName;
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collection(collectionNameToFind).GetAwaiter().GetResult().Should().BeOfType<CollectionDto>();
            AtomicAssetsApiFactory.Version1.CollectionsApi.Collection(collectionNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<CollectionDto.DataDto>();
        }

        [Test]
        public void CollectionStats()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Data.First().CollectionName;
            AtomicAssetsApiFactory.Version1.CollectionsApi.CollectionStats(collectionNameToFind).GetAwaiter().GetResult().Should().BeOfType<StatsDto>();
            AtomicAssetsApiFactory.Version1.CollectionsApi.CollectionStats(collectionNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<StatsDto.DataDto>();
        }

        [Test]
        public void CollectionLogs()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Data.First().CollectionName;
            AtomicAssetsApiFactory.Version1.CollectionsApi.CollectionLogs(collectionNameToFind).GetAwaiter().GetResult().Should().BeOfType<LogsDto>();
            AtomicAssetsApiFactory.Version1.CollectionsApi.CollectionLogs(collectionNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<LogsDto.DataDto[]>();
        }
    }
}