using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Schemas
{
    public class SchemasDto
    {
        [JsonProperty("success")]
        //! Whether the Request was Successfull or not
        public bool Success { get; set; }

        [JsonProperty("data")]
        //! The Data returned from the API 
        public DataDto[] Data { get; set; }

        public class DataDto
        {
            [JsonProperty("contract")]
            //! The name of the Smart Contract 
            public string Contract { get; set; }

            [JsonProperty("schema_name")]
            public string SchemaName { get; set; }

            [JsonProperty("format")]
            public FormatDto[] Format { get; set; }

            [JsonProperty("created_at_block")]
            //! The Block Number this was created 
            public string CreatedAtBlock { get; set; }

            [JsonProperty("created_at_time")]
            //! The Time this was created 
            public string CreatedAtTime { get; set; }

            [JsonProperty("collection")]
            //! The Collection this belongs to 
            public CollectionDto Collection { get; set; }

            public class FormatDto
            {
                [JsonProperty("name")]
                //! The Name 
                public string Name { get; set; }

                [JsonProperty("type")]
                //! The Type of an Attribute 
                public string Type { get; set; }
            }

            public class CollectionDto
            {
                [JsonProperty("collection_name")]
                //! The Name of the Collection 
                public string CollectionName { get; set; }

                [JsonProperty("name")]
                //! The Name 
                public string Name { get; set; }

                [JsonProperty("img")]
                //! The IPFS-CID of the Image 
                public string Image { get; set; }

                [JsonProperty("author")]
                //! The Author 
                public string Author { get; set; }

                [JsonProperty("allow_notify")]
                //! If this Collection allows notifications 
                public bool AllowNotify { get; set; }

                [JsonProperty("authorized_accounts")]
                //! The Accounts authorized to mint  
                public string[] AuthorizedAccounts { get; set; }

                [JsonProperty("notify_accounts")]
                //! The Accounts being notified when minting 
                public string[] NotifyAccounts { get; set; }

                [JsonProperty("market_fee")]
                //! The Market Fee 
                public float MarketFee { get; set; }

                [JsonProperty("created_at_block")]
                //! The Block Number this was created 
                public string CreatedAtBlock { get; set; }

                [JsonProperty("created_at_time")]
                //! The Time this was created 
                public string CreatedAtTime { get; set; }
            }
        }
    }
}
