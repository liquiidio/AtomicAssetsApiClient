using System.Linq;
using AtomicAssetsApiClient.Templates;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Templates
{
    [TestClass]
    public class TemplatesApiTest
    {
        [TestMethod]
        public void Templates()
        {
            AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Should().BeOfType<TemplatesDto>();
            AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.Should().BeOfType<TemplatesDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.TemplatesApi.Templates(new TemplatesUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.TemplatesApi.Templates(new TemplatesUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<TemplatesDto>();
            AtomicAssetsApiFactory.Version1.TemplatesApi.Templates(new TemplatesUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<TemplatesDto.DataDto[]>();
        }

        [TestMethod]
        public void Template()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.First().Collection.CollectionName;
            var templateIdToFind = AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.First().TemplateId;
            AtomicAssetsApiFactory.Version1.TemplatesApi.Template(collectionNameToFind, templateIdToFind).GetAwaiter().GetResult().Should().BeOfType<TemplateDto>();
            AtomicAssetsApiFactory.Version1.TemplatesApi.Template(collectionNameToFind, templateIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<TemplateDto.DataDto>();
        }

        [TestMethod]
        public void TemplateStats()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.First().Collection.CollectionName;
            var templateIdToFind = AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.First().TemplateId;
            AtomicAssetsApiFactory.Version1.TemplatesApi.TemplateStats(collectionNameToFind, templateIdToFind).GetAwaiter().GetResult().Should().BeOfType<StatsDto>();
            AtomicAssetsApiFactory.Version1.TemplatesApi.TemplateStats(collectionNameToFind, templateIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<StatsDto.DataDto>();
        }

        [TestMethod]
        public void TemplateLogs()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.First().Collection.CollectionName;
            var templateIdToFind = AtomicAssetsApiFactory.Version1.TemplatesApi.Templates().GetAwaiter().GetResult().Data.First().TemplateId;
            AtomicAssetsApiFactory.Version1.TemplatesApi.TemplateLogs(collectionNameToFind, templateIdToFind).GetAwaiter().GetResult().Should().BeOfType<LogsDto>();
            AtomicAssetsApiFactory.Version1.TemplatesApi.TemplateLogs(collectionNameToFind, templateIdToFind).GetAwaiter().GetResult().Data.Should().BeOfType<LogsDto.DataDto[]>();
        }
    }
}