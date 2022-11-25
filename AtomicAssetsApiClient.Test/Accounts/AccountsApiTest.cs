using System.Linq;
using AtomicAssetsApiClient.Core.Accounts;
using FluentAssertions;
using NUnit.Framework;

namespace AtomicAssetsApiClient.Test.Accounts
{
    [TestFixture]
    public class AccountsApiTest
    {
        [Test]
        [Ignore("This test is failing at the moment as the AtomicAssents endpoint is down. We always receive an Internal Server Error. Add this test back in when their endpoint is working again")]
        public void Accounts()
        {
            AtomicAssetsApiFactory.Version1.AccountsApi.Accounts().Should().BeOfType<AccountsDto>();
            AtomicAssetsApiFactory.Version1.AccountsApi.Accounts().GetAwaiter().GetResult().Data.Should().BeOfType<AccountsDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.AccountsApi.Accounts().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.AccountsApi.Accounts(new AccountsUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.AccountsApi.Accounts(new AccountsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).Should().BeOfType<AccountsDto>();
            AtomicAssetsApiFactory.Version1.AccountsApi.Accounts(new AccountsUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<AccountsDto.DataDto[]>();
        }

        [Test]
        [Ignore("This test is failing at the moment as the AtomicAssents endpoint is down. We always receive an Internal Server Error. Add this test back in when their endpoint is working again")]
        public void Account()
        {
            var accountNameToFind = AtomicAssetsApiFactory.Version1.AccountsApi.Accounts().GetAwaiter().GetResult().Data.First().Account;
            AtomicAssetsApiFactory.Version1.AccountsApi.Account(accountNameToFind).Should().BeOfType<AccountDto>();
            AtomicAssetsApiFactory.Version1.AccountsApi.Account(accountNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<AccountDto.DataDto>();
        }

        [Test]
        [Ignore("This test is failing at the moment as the AtomicAssents endpoint is down. We always receive an Internal Server Error. Add this test back in when their endpoint is working again")]
        public void Collection()
        {
            var accountNameToFind = AtomicAssetsApiFactory.Version1.AccountsApi.Accounts().GetAwaiter().GetResult().Data.First().Account;
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.CollectionsApi.Collections().GetAwaiter().GetResult().Data.First().CollectionName;
            AtomicAssetsApiFactory.Version1.AccountsApi.Collection(accountNameToFind, collectionNameToFind).Should().BeOfType<AccountCollectionDto>();
            AtomicAssetsApiFactory.Version1.AccountsApi.Collection(accountNameToFind, collectionNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<AccountCollectionDto.DataDto>();
        }
    }
}
