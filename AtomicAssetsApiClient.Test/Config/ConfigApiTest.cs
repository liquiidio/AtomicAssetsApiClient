using AtomicAssetsApiClient.Config;
using FluentAssertions;
using NUnit.Framework;

namespace AtomicAssetsApiClient.Test.Config
{
    [TestFixture]
    public class ConfigApiTest
    {
        [Test]
        public void Config()
        {
            AtomicAssetsApiFactory.Version1.ConfigApi.Config().GetAwaiter().GetResult().Should().BeOfType<ConfigDto>();
        }
    }
}