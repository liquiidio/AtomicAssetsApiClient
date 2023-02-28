using System.Linq;
using AtomicAssetsApiClient.Burns;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Burns
{
    [TestClass]
    public class BurnsApiTest
    {
        private const string TEST_COLLECTION = "elementblobs";
        [TestMethod]
        public void Burns()
        {
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).GetAwaiter().GetResult().Should().BeOfType<BurnsDto>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).GetAwaiter().GetResult().Data.Should().BeOfType<BurnsDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION).WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION).WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<BurnsDto>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION).WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<BurnsDto.DataDto[]>();
        }

        [TestMethod]
        [Ignore("Response ended prematurely error.")]
        public void Account()
        {
            var accountNameToFind = AtomicAssetsApiFactory.Version1.BurnsApi.Burns(new BurnsUriParameterBuilder().WithCollectionName(TEST_COLLECTION)).GetAwaiter().GetResult().Data.First().Account;
            AtomicAssetsApiFactory.Version1.BurnsApi.Account(accountNameToFind).GetAwaiter().GetResult().Should().BeOfType<BurnDto>();
            AtomicAssetsApiFactory.Version1.BurnsApi.Account(accountNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<BurnDto.DataDto>();
        }
    }
}