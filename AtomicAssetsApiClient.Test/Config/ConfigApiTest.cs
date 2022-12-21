using AtomicAssetsApiClient.Config;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Config
{
    [TestClass]
    public class ConfigApiTest
    {
        [TestMethod]
        public void Config()
        {
            AtomicAssetsApiFactory.Version1.ConfigApi.Config().GetAwaiter().GetResult().Should().BeOfType<ConfigDto>();
        }
    }
}