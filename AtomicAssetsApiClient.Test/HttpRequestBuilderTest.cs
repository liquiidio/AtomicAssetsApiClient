using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test
{
    [TestClass]
    public class HttpRequestBuilderTest
    {
        private readonly Uri _testUri = new Uri("http://test.com");

        [TestMethod]
        public void Build()
        {
            HttpRequestBuilder.GetRequest(_testUri)
                .Build()
                .Should()
                .BeEquivalentTo(new HttpRequestMessage(HttpMethod.Get, _testUri));

            HttpRequestBuilder.PostRequest(_testUri)
                .Build()
                .Should()
                .BeEquivalentTo(new HttpRequestMessage(HttpMethod.Post, _testUri));
        }

        [TestMethod]
        public void Build_with_content()
        {
            var expectedRequestMessage = new HttpRequestMessage(HttpMethod.Get, _testUri)
            {
                Content = new StringContent("testContent", Encoding.UTF8, "application/json")
            };

            HttpRequestBuilder.GetRequest(_testUri)
                .WithContent("testContent")
                .Build()
                .Should()
                .BeEquivalentTo(expectedRequestMessage);
        }

        [TestMethod]
        public void Build_with_authentication()
        {
            var expectedRequestMessage = new HttpRequestMessage(HttpMethod.Get, _testUri);
            expectedRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", "token");

            HttpRequestBuilder.GetRequest(_testUri)
                .WithAuthentication("token")
                .Build()
                .Should()
                .BeEquivalentTo(expectedRequestMessage);
        }
    }
}