using System.Linq;
using AtomicAssetsApiClient.Burns;
using FluentAssertions;
using NUnit.Framework;

namespace AtomicAssetsApiClient.Test.Burns
{
    [TestFixture]
    public class BurnsApiTest
    {
        private const string TEST_COLLECTION = "elementblobs";
        [Test]
        public void Burns()
        {
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).Should().BeOfType<BurnsDto>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).Data.Should().BeOfType<BurnsDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION).WithLimit(1)).Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION).WithOrder(SortStrategy.Ascending)).Should().BeOfType<BurnsDto>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION).WithOrder(SortStrategy.Ascending)).Data.Should().BeOfType<BurnsDto.DataDto[]>();
        }

        [Test]
        public void Account()
        {
            var accountNameToFind = AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).Data.First().Account;
            AtomicAssetsApiFactory.Version1.BurnsApi.Account(accountNameToFind).Should().BeOfType<BurnDto>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Account(accountNameToFind).Data.Should().BeOfType<BurnDto.DataDto>();
        }
    }
}