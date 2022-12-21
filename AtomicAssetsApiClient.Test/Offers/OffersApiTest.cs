using System.Linq;
using AtomicAssetsApiClient.Offers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Offers
{
    [TestClass]
    public class OffersApiTest
    {
        [TestMethod]
        public void Offers()
        {
            AtomicAssetsApiFactory.Version1.OffersApi.Offers().GetAwaiter().GetResult().Should().BeOfType<OffersDto>();
            AtomicAssetsApiFactory.Version1.OffersApi.Offers().GetAwaiter().GetResult().Data.Should().BeOfType<OffersDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.OffersApi.Offers().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.OffersApi.Offers(new OffersUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.OffersApi.Offers(new OffersUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<OffersDto>();
            AtomicAssetsApiFactory.Version1.OffersApi.Offers(new OffersUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<OffersDto.DataDto[]>();
        }

        [TestMethod]
        public void Offer()
        {
            var offerIdToFind = AtomicAssetsApiFactory.Version1.OffersApi.Offers().GetAwaiter().GetResult().Data.First().OfferId;
            AtomicAssetsApiFactory.Version1.OffersApi.Offer(offerIdToFind).GetAwaiter().GetResult().Should().BeOfType<OfferDto>();
            AtomicAssetsApiFactory.Version1.OffersApi.Offer(offerIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<OfferDto.DataDto>();
        }

        [TestMethod]
        public void OfferLogs()
        {
            var offerIdToFind = AtomicAssetsApiFactory.Version1.OffersApi.Offers().GetAwaiter().GetResult().Data.First().OfferId;
            AtomicAssetsApiFactory.Version1.OffersApi.OfferLogs(offerIdToFind).GetAwaiter().GetResult().Should().BeOfType<LogsDto>();
            AtomicAssetsApiFactory.Version1.OffersApi.OfferLogs(offerIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<LogsDto.DataDto[]>();
        }
    }
}