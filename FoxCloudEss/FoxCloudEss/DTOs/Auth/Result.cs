using System.Text.Json.Serialization;

namespace FoxCloudEss
{
    internal class Result
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("access")]
        public int Access { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}