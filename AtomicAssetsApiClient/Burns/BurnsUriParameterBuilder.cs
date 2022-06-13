using System.Text;

namespace AtomicAssetsApiClient.Burns
{
    public class BurnsUriParameterBuilder
    {
/* A private variable that is used to store the value of the collectionName parameter. */
        private string _collectionName;
/* A private variable that is used to store the value of the schemaName parameter. */
        private string _schemaName;
/* A private variable that is used to store the value of the templateId parameter. */
        private string _templateId;
/* A private variable that is used to store the value of the collectionBlacklist parameter. */
        private string _collectionBlacklist;
/* A private variable that is used to store the value of the collectionWhitelist parameter. */
        private string _collectionWhitelist;
/* A private variable that is used to store the value of the ids parameter. */
        private string _ids;
/* A private variable that is used to store the value of the lowerBound parameter. */
        private string _lowerBound;
/* A private variable that is used to store the value of the upperBound parameter. */
        private string _upperBound;
/* A nullable integer specifying the page. */
        private int? _page;
/* A nullable integer specifying the limit of returned values. */
        private int? _limit;
/* A nullable enum specifying the sortStrategy. */
        private SortStrategy? _sortStrategy;

        public BurnsUriParameterBuilder WithCollectionName(string collectionName)
        {
            _collectionName = collectionName;
            return this;
        }

        public BurnsUriParameterBuilder WithSchemaName(string schemaName)
        {
            _schemaName = schemaName;
            return this;
        }

        public BurnsUriParameterBuilder WithTemplateId(string templateId)
        {
            _templateId = templateId;
            return this;
        }

        public BurnsUriParameterBuilder WithCollectionBlacklist(string[] collectionBlacklist)
        {
            _collectionBlacklist = string.Join(",", collectionBlacklist);
            return this;
        }

        public BurnsUriParameterBuilder WithCollectionWhitelist(string[] collectionWhitelist)
        {
            _collectionWhitelist = string.Join(",", collectionWhitelist);
            return this;
        }

        public BurnsUriParameterBuilder WithIds(string[] ids)
        {
            _ids = string.Join(",", ids);
            return this;
        }

        public BurnsUriParameterBuilder WithLowerBound(string lowerBound)
        {
            _lowerBound = lowerBound;
            return this;
        }

        public BurnsUriParameterBuilder WithUpperBound(string upperBound)
        {
            _upperBound = upperBound;
            return this;
        }

        public BurnsUriParameterBuilder WithPage(int page)
        {
            _page = page;
            return this;
        }

        public BurnsUriParameterBuilder WithLimit(int limit)
        {
            _limit = limit;
            return this;
        }

        public BurnsUriParameterBuilder WithOrder(SortStrategy sorting)
        {
            _sortStrategy = sorting;
            return this;
        }

        public string Build()
        {
            var parameterString = new StringBuilder("?");
            if (!string.IsNullOrEmpty(_collectionName))
            {
                parameterString.Append($"&collection_name={_collectionName}");
            }
            if (!string.IsNullOrEmpty(_schemaName))
            {
                parameterString.Append($"&schema_name={_schemaName}");
            }
            if (!string.IsNullOrEmpty(_templateId))
            {
                parameterString.Append($"&template_id={_templateId}");
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

            return parameterString.ToString();
        }
    }
}
