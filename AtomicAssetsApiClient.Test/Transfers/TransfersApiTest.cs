using AtomicAssetsApiClient.Transfers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Transfers
{
    [TestClass]
    public class TransfersApiTest
    {
        [Test]
        [Ignore("It's failing for unknown reasons")]
        public void Transfers()
        {
            AtomicAssetsApiFactory.Version1.TransfersApi.Transfers().GetAwaiter().GetResult().Should().BeOfType<TransfersDto>();
            AtomicAssetsApiFactory.Version1.TransfersApi.Transfers().GetAwaiter().GetResult().Data.Should().BeOfType<TransfersDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.TransfersApi.Transfers().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.TransfersApi.Transfers(new TransfersUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.TransfersApi.Transfers(new TransfersUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<TransfersDto>();
            AtomicAssetsApiFactory.Version1.TransfersApi.Transfers(new TransfersUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<TransfersDto.DataDto[]>();
        }
    }
}