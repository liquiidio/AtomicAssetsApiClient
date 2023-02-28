using AtomicAssetsApiClient.Collections;
using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountDto
    {
        [JsonProperty("success")]
        //! Whether the Request was Successfull or not
        public bool Success { get; set; }
        
        [JsonProperty("data")]
        //! The Data returned from the API 
        public DataDto[] Data { get; set; }

        public class DataDto
        {
            [JsonProperty("collections")]
            //! The Templates belonging to this Account
            public CollectionsDto[] Collections { get; set; }

            [JsonProperty("templates")]
            //! The Templates belonging to this Account
            public TemplatesDto[] Templates{ get; set; }

            [JsonProperty("assets")]
            //! The Assets belonging to this account
            public string Assets { get; set; }

            public class CollectionsDto
            {
                [JsonProperty("collection")]
                public CollectionDto[] Collections { get; set; }

                [JsonProperty("assets")]
                //! The Assets belonging to this Schema
                public string Assets { get; set; }
            }

            public class TemplatesDto
            {
                [JsonProperty("template_id")]
                //! Unique Identifier of a Template
                public string TemplateId { get; set; }

                [JsonProperty("assets")]
                //! The Assets belonging to this Schema
                public string Assets { get; set; }
            }
        }
    }
}
