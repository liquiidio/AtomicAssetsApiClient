using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Templates
{
    public class TemplatesDto
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

            [JsonProperty("template_id")]
            //! The unique Identifier of a Template 
            public string TemplateId { get; set; }

            [JsonProperty("max_supply")]
            //! The Maximum Supply 
            public string MaxSupply { get; set; }

            [JsonProperty("issued_supply")]
            //! The issued Supply 
            public string IssuedSupply { get; set; }
            
            [JsonProperty("is_transferable")]
            //! Indicates if an Asset is transferable 
            public bool IsTransferable { get; set; }

            [JsonProperty("is_burnable")]
            //! Indicates if an Asset is burnable 
            public bool IsBurnable { get; set; }

            [JsonProperty("immutable_data")]
            //! The Immutable Data 
            public object ImmutableData { get; set; }

            [JsonProperty("created_at_block")]
            //! The Block Number this was created 
            public string CreatedAtBlock { get; set; }

            [JsonProperty("created_at_time")]
            //! The Time this was created 
            public string CreatedAtTime { get; set; }

            [JsonProperty("collection")]
            //! The Collection this belongs to
            public CollectionDto Collection { get;set; }

            [JsonProperty("scheme")]
            //! The Schema this belongs to
            public SchemaDto Schema { get;set; }

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

            public class SchemaDto
            {
                [JsonProperty("schema_name")]
                //! The Name of the Schema 
                public string SchemaName { get; set; }

                [JsonProperty("format")]
                //! The Format of the Schema 
                public FormatDto[] Format { get; set; }

                [JsonProperty("created_at_block")]
                //! The Block Number this was created 
                public string CreatedAtBlock { get; set; }

                [JsonProperty("created_at_time")]
                //! The Time this was created 
                public string CreatedAtTime { get; set; }

                public class FormatDto
                {
                    [JsonProperty("name")]
                    //! The Name 
                    public string Name { get; set; }

                    [JsonProperty("type")]
                    //! The Type of an Attribute 
                    public string Type { get; set; }
                }
            }
        }
    }
}
