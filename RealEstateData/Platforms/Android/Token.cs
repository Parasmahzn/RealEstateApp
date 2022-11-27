using Newtonsoft.Json;

namespace RealEstateData.Platforms.Android
{
    public class Token
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("tokenType")]

        public string TokenType { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

}
