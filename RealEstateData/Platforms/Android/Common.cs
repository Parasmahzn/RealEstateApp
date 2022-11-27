using Newtonsoft.Json;

namespace RealEstateData.Platforms.Android
{
    public class CommonResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("errors")]
        public object Errors { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
