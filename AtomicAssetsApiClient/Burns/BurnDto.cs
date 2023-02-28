using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Burns
{
    public class BurnDto
    {
        [JsonProperty("success")]
        //! Whether the Request was Successfull or not
        public bool Success { get; set; }

        [JsonProperty("data")]
        //! The Data returned from the API 
        public DataDto Data { get; set; }

        public class DataDto
        {
            [JsonProperty("collections")]
            //! The Collections this belongs to
            public CollectionsDto[] Collections { get; set; }

            [JsonProperty("templates")]
            //! The Templates this belongs to
            public TemplatesDto[] Templates { get; set; }

            [JsonProperty("assets")]
            //! The Assets burned
            public string Assets { get; set; }

            public class CollectionsDto
            {
                [JsonProperty("collection_name")]
                //! The Name of the Collection 
                public string CollectionName { get; set; }

                [JsonProperty("assets")]
                //! The Assets belonging to this Schema
                public string Assets { get; set; }
            }

            public class TemplatesDto
            {
                [JsonProperty("collection_name")]
                //! The Name of the Collection 
                public string CollectionName { get; set; }

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