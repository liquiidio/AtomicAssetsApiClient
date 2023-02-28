using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountCollectionDto
    {
        [JsonProperty("success")]
        //! Whether the Request was Successfull or not
        public bool Success { get; set; }

        [JsonProperty("data")]
        //! The Data returned from the API 
        public DataDto[] Data { get; set; }

        public class DataDto
        {
            [JsonProperty("schemas")]
            //! The Schemas belonging to this Collection
            public SchemasDto[] Schemas{ get; set; }

            [JsonProperty("templates")]
            //! The Templates belongign to this Collection
            public TemplatesDto[] Templates{ get; set; }

            [JsonProperty("assets")]
            //! The Assets belonging to this Schema
            public string Assets { get; set; }

            public class SchemasDto
            {
                [JsonProperty("schema_name")]
                //! The Name of the Schema 
                public string SchemaName { get; set; }

                [JsonProperty("assets")]
                //! The Assets belonging to this Schema
                public string Assets { get; set; }
            }

            public class TemplatesDto
            {
                [JsonProperty("template_id")]
                //! The unique Identifier of a Template 
                public string TemplateId { get;set; }

                [JsonProperty("assets")]
                //! The Assets belonging to this Schema
                public string Assets { get; set; }
            }
        }
    }
}