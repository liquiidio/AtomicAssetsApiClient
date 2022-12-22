using System.Text;

namespace AtomicAssetsApiClient.Schemas
{
    public class SchemasUriParameterBuilder
    {
//! A private variable that is used to store the value of the collectionName parameter. 
        private string _collectionName;

//! A private variable that is used to store the value of the authorisedAccount parameter. 
        private string _authorisedAccount;

//! A private variable that is used to store the value of the schemaName parameter. 
        private string _schemaName;

//! A private variable that is used to store the value of the match parameter. 
        private string _match;

//! A private variable that is used to store the value of the collectionBlacklist parameter. 
        private string _collectionBlacklist;

//! A private variable that is used to store the value of the collectionWhitelistparameter. 
        private string _collectionWhitelist;

//! A private variable that is used to store the value of the ids parameter. 
        private string _ids;

//! A private variable that is used to store the value of the lowerBound parameter. 
        private string _lowerBound;

//! A private variable that is used to store the value of the upperBound parameter. 
        private string _upperBound;

//! A nullable integer specifying previous timestamp. 
        private int? _before;

//! A nullable integer specifying next timestamp. 
        private int? _after;

//! A nullable integer specifying the page. 
        private int? _page;

//! A nullable integer specifying the limit of returned values.
        private int? _limit;

//! A nullable enum specifying the sortStrategy. 
        private SortStrategy? _sortStrategy;

//! A private variable that is used to store the value of the sort parameter. 
        private string _sort;


        /// <summary>
        /// `WithCollectionName` is a function that takes a string as a parameter and returns an
        /// `SchemasUriParameterBuilder` object
        /// </summary>
        /// <param name="collectionName">The name of the collection you want to query.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithCollectionName(string collectionName)
        {
            _collectionName = collectionName;
            return this;
        }


        /// <summary>
        /// This function sets the schema name for the query
        /// </summary>
        /// <param name="schemaName">The name of the schema to use.</param>
        /// <returns>
        /// The ShemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithSchemaName(string schemaName)
        {
            _schemaName = schemaName;
            return this;
        }


        /// <summary>
        /// `WithMatch` sets the `match` parameter
        /// </summary>
        /// <param name="match">The match parameter is used to filter the results. The match parameter is a
        /// string that is matched against the account name.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithMatch(string match)
        {
            _match = match;
            return this;
        }


        /// <summary>
        /// `WithCollectionBlacklist` is a function that takes an array of strings and returns an
        /// `SchemasUriParameterBuilder` object
        /// </summary>
        /// <param name="collectionBlacklist">A list of collections to exclude from the results.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithCollectionBlacklist(string[] collectionBlacklist)
        {
            _collectionBlacklist = string.Join(",", collectionBlacklist);
            return this;
        }


        /// <summary>
        /// `WithCollectionWhitelist` is a function that takes an array of strings and returns an
        /// `SchemasUriParameterBuilder` object
        /// </summary>
        /// <param name="collectionWhitelist">A list of collections to include in the response.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithCollectionWhitelist(string[] collectionWhitelist)
        {
            _collectionWhitelist = string.Join(",", collectionWhitelist);
            return this;
        }


        /// <summary>
        /// `WithAuthorisedAccount` sets the `authorisedAccount` parameter
        /// </summary>
        /// <param name="authorisedAccount">The authorisedAccount parameter is used to filter the results the provided account can edit.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithAuthorisedAccount(string authorisedAccount)
        {
            _authorisedAccount = authorisedAccount;
            return this;
        }


        /// <summary>
        /// This function takes an array of strings and joins them together with a comma
        /// </summary>
        /// <param name="ids">A comma-separated list of account IDs.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithIds(string[] ids)
        {
            _ids = string.Join(",", ids);
            return this;
        }


        /// <summary>
        /// `WithLowerBound` sets the lower bound of the `account_ids` parameter
        /// </summary>
        /// <param name="lowerBound">The lower bound of the accounts to retrieve.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithLowerBound(string lowerBound)
        {
            _lowerBound = lowerBound;
            return this;
        }


        /// <summary>
        /// `WithUpperBound` sets the upper bound of the range of accounts to be returned
        /// </summary>
        /// <param name="upperBound">The upper bound of the range to query.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithUpperBound(string upperBound)
        {
            _upperBound = upperBound;
            return this;
        }


        /// <summary>
        /// `WithBefore` sets the `_before` variable to the value of the `before` parameter
        /// </summary>
        /// <param name="before">The previous values of the results to return.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithBefore(int before)
        {
            _before = before;
            return this;
        }


        /// <summary>
        /// `WithAfter` sets the `_after` variable to the value of the `after` parameter
        /// </summary>
        /// <param name="after">The later values of the results to return.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithAfter(int after)
        {
            _after = after;
            return this;
        }


        /// <summary>
        /// `WithPage` sets the `_page` variable to the value of the `page` parameter
        /// </summary>
        /// <param name="page">The page number of the results to return.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithPage(int page)
        {
            _page = page;
            return this;
        }


        /// <summary>
        /// `WithLimit` sets the `_limit` variable to the value of the `limit` parameter
        /// </summary>
        /// <param name="limit">The number of results to return.</param>
        /// <returns>
        /// The SchemasUriParameterBuilder object.
        /// </returns>
        public SchemasUriParameterBuilder WithLimit(int limit)
        {
            _limit = limit;
            return this;
        }


        /// <summary>
        /// This function sets the sort strategy for the query
        /// </summary>
        /// <param name="SortStrategy"></param>
        /// <returns>
        /// The builder object itself.
        /// </returns>
        public SchemasUriParameterBuilder WithOrder(SortStrategy sorting)
        {
            _sortStrategy = sorting;
            return this;
        }

        /// <summary>
        /// It sets the sort parameter.
        /// </summary>
        /// <param name="sort">The sort order of the results.</param>
        /// <returns>
        /// A new instance of the SchemasUriParameterBuilder class.
        /// </returns>
        public SchemasUriParameterBuilder WithSort(string sort)
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
            if (!string.IsNullOrEmpty(_collectionName))
            {
                parameterString.Append($"&collection_name={_collectionName}");
            }

            if (!string.IsNullOrEmpty(_match))
            {
                parameterString.Append($"&match={_match}");
            }

            if (!string.IsNullOrEmpty(_collectionBlacklist))
            {
                parameterString.Append($"&collection_blacklist={_collectionBlacklist}");
            }

            if (!string.IsNullOrEmpty(_collectionWhitelist))
            {
                parameterString.Append($"&collection_whitelist={_collectionWhitelist}");
            }

            if (!string.IsNullOrEmpty(_authorisedAccount))
            {
                parameterString.Append($"&authorized_account={_authorisedAccount}");
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

            if (!string.IsNullOrEmpty(_schemaName))
            {
                parameterString.Append($"&schema_name={_schemaName}");
            }

            return parameterString.ToString();
        }
    }
}