using Newtonsoft.Json;

namespace AtomicAssetsApiClient.Accounts
{
    public class AccountsDto
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
            //! Name of the Account queried
            public string Account{ get; set; }

            [JsonProperty("assets")]
            //! Assets belonging to this Account
            public string Assets { get; set; }
        }
    }
}