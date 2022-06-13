using System.Text;

namespace AtomicAssetsApiClient.Offers
{
    public class OffersUriParameterBuilder
    {
/* A private variable that is used to store the value of the account parameter. */
        private string _account;
/* A private variable that is used to store the value of the sender parameter. */
        private string _sender;
/* A private variable that is used to store the value of the recipient parameter. */
        private string _recipient;
/* A private variable that is used to store the value of the state parameter. */
        private string _state;
/* A nullable boolean specfying recipientContract. */
        private bool? _isRecipientContract;
/* A private variable that is used to store the value of the assetId parameter. */
        private string _assetId;
/* A private variable that is used to store the value of the templateId parameter. */
        private string _templateId;
/* A private variable that is used to store the value of the schemeName parameter. */
        private string _schemaName;
/* A private variable that is used to store the value of the collectionName parameter. */
        private string _collectionName;
/* A private variable that is used to store the value of the accountWhitelist parameter. */
        private string _accountWhitelist;
/* A private variable that is used to store the value of the accountBlacklist parameter. */
        private string _accountBlacklist;
/* A private variable that is used to store the value of the senderAssetWhitelist parameter. */
        private string _senderAssetWhitelist;
/* A private variable that is used to store the value of the senderBlacklist parameter. */
        private string _senderAssetBlacklist;
/* A private variable that is used to store the value of the recipientAssetWhitelist parameter. */
        private string _recipientAssetWhitelist;
/* A private variable that is used to store the value of the recipientAssetBlacklist parameter. */
        private string _recipientAssetBlacklist;
/* A private variable that is used to store the value of the collectionBlacklist parameter. */
        private string _collectionBlacklist;
/* A private variable that is used to store the value of the collectionWhitelist parameter. */
        private string _collectionWhitelist;
/* A private variable that is used to store the value of the Ids parameter. */
        private string _ids;
/* A private variable that is used to store the value of the lowerbond parameter. */
        private string _lowerBound;
/* A private variable that is used to store the value of the upperbond parameter. */
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

        public OffersUriParameterBuilder WithAccountWhitelist(string accountWhitelist)
        {
            _accountWhitelist = accountWhitelist;
            return this;
        }

        public OffersUriParameterBuilder WithAccountBlacklist(string accountBlacklist)
        {
            _accountBlacklist = accountBlacklist;
            return this;
        }

        public OffersUriParameterBuilder WithSenderAssetWhitelist(string senderAssetwhitelist)
        {
            _senderAssetWhitelist = senderAssetwhitelist;
            return this;
        }

        public OffersUriParameterBuilder WithSenderAssetBlacklist(string senderAssetBlacklist)
        {
            _senderAssetBlacklist = senderAssetBlacklist;
            return this;
        }

        public OffersUriParameterBuilder WithRecipientAssetWhitelist(string recipientAssetwhitelist)
        {
            _recipientAssetWhitelist = recipientAssetwhitelist;
            return this;
        }

        public OffersUriParameterBuilder WithRecipientAssetBlacklist(string recipientAssetBlacklist)
        {
            _recipientAssetBlacklist = recipientAssetBlacklist;
            return this;
        }

        public OffersUriParameterBuilder WithAccount(string account)
        {
            _account = account;
            return this;
        }

        public OffersUriParameterBuilder WithSender(string sender)
        {
            _sender = sender;
            return this;
        }

        public OffersUriParameterBuilder WithRecipient(string recipient)
        {
            _recipient = recipient;
            return this;
        }

        public OffersUriParameterBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public OffersUriParameterBuilder WithIsRecipientContract(bool isRecipientContract)
        {
            _isRecipientContract = isRecipientContract;
            return this;
        }

        public OffersUriParameterBuilder WithAssetId(string assetId)
        {
            _assetId = assetId;
            return this;
        }

        public OffersUriParameterBuilder WithTemplateId(string temlpateId)
        {
            _templateId = temlpateId;
            return this;
        }

        public OffersUriParameterBuilder WithCollectionName(string collectionName)
        {
            _collectionName = collectionName;
            return this;
        }

        public OffersUriParameterBuilder WithSchemaName(string schemaName)
        {
            _schemaName = schemaName;
            return this;
        }

        public OffersUriParameterBuilder WithCollectionBlacklist(string[] collectionBlacklist)
        {
            _collectionBlacklist = string.Join(",", collectionBlacklist);
            return this;
        }

        public OffersUriParameterBuilder WithCollectionWhitelist(string[] collectionWhitelist)
        {
            _collectionWhitelist = string.Join(",", collectionWhitelist);
            return this;
        }

        public OffersUriParameterBuilder WithIds(string[] ids)
        {
            _ids = string.Join(",", ids);
            return this;
        }

        public OffersUriParameterBuilder WithLowerBound(string lowerBound)
        {
            _lowerBound = lowerBound;
            return this;
        }

        public OffersUriParameterBuilder WithUpperBound(string upperBound)
        {
            _upperBound = upperBound;
            return this;
        }

        public OffersUriParameterBuilder WithBefore(int before)
        {
            _before = before;
            return this;
        }

        public OffersUriParameterBuilder WithAfter(int after)
        {
            _after = after;
            return this;
        }

        public OffersUriParameterBuilder WithPage(int page)
        {
            _page = page;
            return this;
        }

        public OffersUriParameterBuilder WithLimit(int limit)
        {
            _limit = limit;
            return this;
        }

        public OffersUriParameterBuilder WithOrder(SortStrategy sorting)
        {
            _sortStrategy = sorting;
            return this;
        }

        public OffersUriParameterBuilder WithSort(string sort)
        {
            _sort = sort;
            return this;
        }

        public string Build()
        {
            var parameterString = new StringBuilder("?");
            if (!string.IsNullOrEmpty(_account))
            {
                parameterString.Append($"account={_account}");
            }
            if (!string.IsNullOrEmpty(_sender))
            {
                parameterString.Append($"sender={_sender}");
            }
            if (!string.IsNullOrEmpty(_recipient))
            {
                parameterString.Append($"recipient={_recipient}");
            }
            if (!string.IsNullOrEmpty(_state))
            {
                parameterString.Append($"state={_state}");
            }
            if (_isRecipientContract.HasValue)
            {
                parameterString.Append($"is_recipient_contract={_isRecipientContract}");
            }
            if (!string.IsNullOrEmpty(_assetId))
            {
                parameterString.Append($"asset_id={_assetId}");
            }
            if (!string.IsNullOrEmpty(_templateId))
            {
                parameterString.Append($"template_id={_templateId}");
            }
            if (!string.IsNullOrEmpty(_accountWhitelist))
            {
                parameterString.Append($"account_whitelist={_accountWhitelist}");
            }
            if (!string.IsNullOrEmpty(_accountBlacklist))
            {
                parameterString.Append($"account_blacklist={_accountBlacklist}");
            }
            if (!string.IsNullOrEmpty(_senderAssetWhitelist))
            {
                parameterString.Append($"sender_asset_whitelist={_senderAssetWhitelist}");
            }
            if (!string.IsNullOrEmpty(_senderAssetBlacklist))
            {
                parameterString.Append($"sender_asset_blacklist={_senderAssetBlacklist}");
            }
            if (!string.IsNullOrEmpty(_recipientAssetWhitelist))
            {
                parameterString.Append($"recipient_asset_whitelist={_recipientAssetWhitelist}");
            }
            if (!string.IsNullOrEmpty(_recipientAssetBlacklist))
            {
                parameterString.Append($"recipient_asset_blacklist={_recipientAssetBlacklist}");
            }
            if (!string.IsNullOrEmpty(_collectionName))
            {
                parameterString.Append($"&collection_name={_collectionName}");
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
            if (!string.IsNullOrEmpty(_schemaName))
            {
                parameterString.Append($"&schema_name={_schemaName}");
            }

            return parameterString.ToString();
        }
    }
}
