using System.Net.Http;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test
{
    [TestClass]
    public class HttpResponseMessageExtensionTest
    {
        [TestMethod]
        public void ContentAs()
        {
            new HttpResponseMessage
            {
                Content = new StringContent("{\"Id\": \"uppercase_id_property\",\"Name\": \"uppercase_name_property\"}")
            }
            .ContentAs<TestObject>()
            .Should()
            .BeEquivalentTo(new TestObject
            {
                Id = "uppercase_id_property",
                Name = "uppercase_name_property"
            });

            new HttpResponseMessage
            {
                Content = new StringContent("{\"id\": \"lowercase_id_property\",\"name\": \"lowercase_name_property\"}")
            }
            .ContentAs<TestObject>()
            .Should()
            .BeEquivalentTo(new TestObject
            {
                Id = "lowercase_id_property",
                Name = "lowercase_name_property"
            });
        }

        public class TestObject
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
