using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountCollectionDto
    {
        [JsonProperty("success")]
        /* A boolean value that is returned by the API. It is true if the request was successful and false if it was not. */
        public bool Success { get; set; }

        [JsonProperty("data")]
        /* A collection of DataDto objects. */
        public DataDto[] Data { get; set; }

        public class DataDto
        {
            [JsonProperty("schemas")]
            /* A property of the DataDto class. It is an array of SchemasDto objects. */
            public SchemasDto[] Schemas{ get; set; }

            [JsonProperty("templates")]
            /* A property of the DataDto class. It is an array of TemplatesDto objects. */
            public TemplatesDto[] Templates{ get; set; }

            [JsonProperty("assets")]
            /* A property of the DataDto class. It is a string that contains the number of assets that the account has. */
            public string Assets { get; set; }

            public class SchemasDto
            {
                [JsonProperty("schema_name")]
                /* A property of the SchemasDto class. It is a string that contains the name of the schema. */
                public string SchemaName { get; set; }

                [JsonProperty("assets")]
                /* A property of the DataDto class. It is a string that contains the number of assets that the account has. */
                public string Assets { get; set; }
            }

            public class TemplatesDto
            {
                [JsonProperty("template_id")]
                /* A property of the TemplatesDto class. It is a string that contains the id of the template. */
                public string TemplateId { get; set; }

                [JsonProperty("assets")]
                /* A property of the DataDto class. It is a string that contains the number of assets that the account has. */
                public string Assets { get; set; }
            }
        }
    }
}
