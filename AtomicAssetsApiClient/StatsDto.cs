using Newtonsoft.Json;

namespace AtomicAssetsApiClient
{
    public class StatsDto
    {
        [JsonProperty("success")]
        //! Whether the Request was Successfull or not
        public bool Success { get; set; }

        [JsonProperty("data")]
        //! The Data returned from the API 
        public DataDto Data { get; set; }

        [JsonProperty("query_time")]
        //! Time this Query took
        public long QueryTime { get; set; }

        public class DataDto
        {
            [JsonProperty("template_mint")]
            public int TemplateMint { get; set; }
        }
    }
}