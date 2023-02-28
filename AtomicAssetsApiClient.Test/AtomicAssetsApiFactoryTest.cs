using System.Threading;
using AtomicAssetsApiClient.Accounts;
using AtomicAssetsApiClient.Assets;
using AtomicAssetsApiClient.Burns;
using AtomicAssetsApiClient.Collections;
using AtomicAssetsApiClient.Config;
using AtomicAssetsApiClient.Offers;
using AtomicAssetsApiClient.Schemas;
using AtomicAssetsApiClient.Templates;
using AtomicAssetsApiClient.Transfers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test
{
    [TestClass]
    public class AtomicAssetsApiFactoryTest
    {
        [TestMethod]
        public void AccountsApi() => Assert.AreEqual(typeof(AccountsApi),AtomicAssetsApiFactory.Version1.AccountsApi.GetType());

        [TestMethod]
        public void AssetsApi() => Assert.AreEqual(typeof(AssetsApi),AtomicAssetsApiFactory.Version1.AssetsApi.GetType());

        [TestMethod]
        public void BurnsApi() => Assert.AreEqual(typeof(BurnsApi),AtomicAssetsApiFactory.Version1.BurnsApi.GetType());

        [TestMethod]
        public void CollectionsApi() => Assert.AreEqual(typeof(CollectionsApi),AtomicAssetsApiFactory.Version1.CollectionsApi.GetType());

        [TestMethod]
        public void ConfigApi() => Assert.AreEqual(typeof(ConfigApi),AtomicAssetsApiFactory.Version1.ConfigApi.GetType());

        [TestMethod]
        public void OffersApi() => Assert.AreEqual(typeof(OffersApi),AtomicAssetsApiFactory.Version1.OffersApi.GetType());

        [TestMethod]
        public void SchemasApi() => Assert.AreEqual(typeof(SchemasApi),AtomicAssetsApiFactory.Version1.SchemasApi.GetType());

        [TestMethod]
        public void TemplatesApi() => Assert.AreEqual(typeof(TemplatesApi),AtomicAssetsApiFactory.Version1.TemplatesApi.GetType());

        [TestMethod]
        public void TransfersApi() => Assert.AreEqual(typeof(TransfersApi),AtomicAssetsApiFactory.Version1.TransfersApi.GetType());
    }
}
