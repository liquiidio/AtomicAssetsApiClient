using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Burns
{
    public class BurnsDto
    {
        [JsonProperty("success")]
        //! Whether the Request was Successfull or not
        public bool Success { get; set; }

        [JsonProperty("data")]
        //! The Data returned from the API 
        public DataDto[] Data { get; set; }

        public class DataDto
        {
            [JsonProperty("account")]
            //! Account that burned the Assets
            public string Account{ get; set; }

            [JsonProperty("assets")]
            //! The Assets burnged
            public string Assets { get; set; }
        }
    }
}