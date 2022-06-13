using System.Text;

namespace AtomicAssetsApiClient.Collections
{
    public class CollectionsUriParameterBuilder
    {
/* A private variable that is used to store the value of the author parameter. */
        private string _author;
/* A private variable that is used to store the value of the match parameter. */
        private string _match;
/* A private variable that is used to store the value of the authorisedAccount parameter. */
        private string _authorisedAccount;
/* A private variable that is used to store the value of the notifyAccount parameter. */
        private string _notifyAccount;
/* A private variable that is used to store the value of the collectionBlacklist parameter. */
        private string _collectionBlacklist;
/* A private variable that is used to store the value of the collectionWhitelist parameter. */
        private string _collectionWhitelist;
/* A private variable that is used to store the value of the Ids parameter. */
        private string _ids;
/* A private variable that is used to store the value of the lowerBound parameter. */
        private string _lowerBound;
/* A private variable that is used to store the value of the upperBound parameter. */
        private string _upperBound;
/* A nullable boolean specfying results based on previous timestamp.  */
        private int? _before;
/* A nullable boolean specfying results based on next timestamp.  */
        private int? _after;
/* A nullable integer specifying the page. */ 
        private int? _page;
/* A nullable integer specifying the limit of returned values. */
        private int? _limit;
/* A nullable enum specifying the sortStrategy. */
        private SortStrategy? _sortStrategy;

        private string _sort;


/// <summary>
/// `WithAuthor` sets the `author` parameter
/// </summary>
/// <param name="author">The author parameter is used to filter the results. The owner parameter is a
/// string that is matched against the account name.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
         public CollectionsUriParameterBuilder WithAuthor(string author)
        {
            _author = author;
            return this;
        }


/// <summary>
/// `WithMatch` sets the `match` parameter
/// </summary>
/// <param name="match">The match parameter is used to filter the results. The match parameter is a
/// string that is matched against the account name.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithMatch(string match)
        {
            _match = match;
            return this;
        }


/// <summary>
/// `WithCollectionBlacklist` is a function that takes an array of strings and returns an
/// `AssetsUriParameterBuilder` object
/// </summary>
/// <param name="collectionBlacklist">A list of collections to exclude from the results.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithCollectionBlacklist(string[] collectionBlacklist)
        {
            _collectionBlacklist = string.Join(",", collectionBlacklist);
            return this;
        }


/// <summary>
/// `WithCollectionWhitelist` is a function that takes an array of strings and returns an
/// `AssetsUriParameterBuilder` object
/// </summary>
/// <param name="collectionWhitelist">A list of collections to include in the response.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithCollectionWhitelist(string[] collectionWhitelist)
        {
            _collectionWhitelist = string.Join(",", collectionWhitelist);
            return this;
        }


/// <summary>
/// `WithAuthorisedAccount` sets the `authorisedAccount` parameter
/// </summary>
/// <param name="authorisedAccount">The authorisedAccount parameter is used to filter the results. The authorisedAccount parameter is a
/// string that is matched against the account name.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithAuthorisedAccount(string authorisedAccount)
        {
            _authorisedAccount = authorisedAccount;
            return this;
        }


/// <summary>
/// > This function takes an array of strings and joins them together with a comma
/// </summary>
/// <param name="ids">A comma-separated list of account IDs.</param>
/// <returns>
/// A string
/// </returns>
        public CollectionsUriParameterBuilder WithIds(string[] ids)
        {
            _ids = string.Join(",", ids);
            return this;
        }


/// <summary>
/// `WithNotifyAccount` sets the `notifyAccount` parameter
/// </summary>
/// <param name="notifyAccount">The notifyAccount parameter is used to filter the results. The notifyAccount parameter is a
/// string that is matched against the account name.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithNotifyAccount(string notifyAccount)
        {
            _notifyAccount = notifyAccount;
            return this;
        }


/// <summary>
/// `WithLowerBound` sets the lower bound of the `account_ids` parameter
/// </summary>
/// <param name="lowerBound">The lower bound of the accounts to retrieve.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithLowerBound(string lowerBound)
        {
            _lowerBound = lowerBound;
            return this;
        }


/// <summary>
/// `WithUpperBound` sets the upper bound of the range of accounts to be returned
/// </summary>
/// <param name="upperBound">The upper bound of the range to query.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithUpperBound(string upperBound)
        {
            _upperBound = upperBound;
            return this;
        }


/// <summary>
/// `WithBefore` sets the `_before` variable to the value of the `before` parameter
/// </summary>
/// <param name="before">The previous values of the results to return.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithBefore(int before)
        {
            _before = before;
            return this;
        }


/// <summary>
/// `WithAfter` sets the `_after` variable to the value of the `after` parameter
/// </summary>
/// <param name="after">The previous values of the results to return.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithAfter(int after)
        {
            _after = after;
            return this;
        }


/// <summary>
/// `WithPage` sets the `_page` variable to the value of the `page` parameter
/// </summary>
/// <param name="page">The page number of the results to return.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithPage(int page)
        {
            _page = page;
            return this;
        }


/// <summary>
/// `WithLimit` sets the `_limit` variable to the value of the `limit` parameter
/// </summary>
/// <param name="limit">The number of results to return.</param>
/// <returns>
/// The CollectionsUriParameterBuilder object.
/// </returns>
        public CollectionsUriParameterBuilder WithLimit(int limit)
        {
            _limit = limit;
            return this;
        }


/// <summary>
/// > This function sets the sort strategy for the query
/// </summary>
/// <param name="SortStrategy"></param>
/// <returns>
/// The builder object itself.
/// </returns>
        public CollectionsUriParameterBuilder WithOrder(SortStrategy sorting)
        {
            _sortStrategy = sorting;
            return this;
        }

        public CollectionsUriParameterBuilder WithSort(string sort)
        {
            _sort = sort;
            return this;
        }


/// <summary>
/// It builds a query string based on the parameters that have been set
/// </summary>
/// <returns>
/// A string that contains the parameters for the query.
/// </returns>
        public string Build()
        {
            var parameterString = new StringBuilder("?");
            if (!string.IsNullOrEmpty(_author))
            {
                parameterString.Append($"&author={_author}");
            }
            if (!string.IsNullOrEmpty(_match))
            {
                parameterString.Append($"&match={_match}");
            }
            if (!string.IsNullOrEmpty(_authorisedAccount))
            {
                parameterString.Append($"&authorized_account={_authorisedAccount}");
            }
            if (!string.IsNullOrEmpty(_notifyAccount))
            {
                parameterString.Append($"&notify_account={_notifyAccount}");
            }
            if (!string.IsNullOrEmpty(_collectionBlacklist))
            {
                parameterString.Append($"&collection_blacklist={_collectionBlacklist}");
            }
            if (!string.IsNullOrEmpty(_collectionWhitelist))
            {
                parameterString.Append($"&collection_whitelist={_collectionWhitelist}");
            }
            if (!string.IsNullOrEmpty(_ids))
            {
                parameterString.Append($"&ids={_ids}");
            }
            if (!string.IsNullOrEmpty(_lowerBound))
            {
                parameterString.Append($"&lower_bound={_lowerBound}");
            }
            if (!string.IsNullOrEmpty(_upperBound))
            {
                parameterString.Append($"&upper_bound={_upperBound}");
            }
            if (_before.HasValue)
            {
                parameterString.Append($"&before={_before}");
            }
            if (_after.HasValue)
            {
                parameterString.Append($"&after={_after}");
            }
            if (_page.HasValue)
            {
                parameterString.Append($"&page={_page}");
            }
            if (_limit.HasValue)
            {
                parameterString.Append($"&limit={_limit}");
            }
            if (_sortStrategy.HasValue)
            {
                switch (_sortStrategy)
                {
                    case SortStrategy.Ascending:
                        parameterString.Append("&order=asc");
                        break;
                    case SortStrategy.Descending:
                        parameterString.Append("&order=desc");
                        break;
                }
            }
            if (!string.IsNullOrEmpty(_sort))
            {
                parameterString.Append($"&sort={_sort}");
            }

            return parameterString.ToString();
        }
    }
}
