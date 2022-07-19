using System.Text.Json.Serialization;

namespace FoxCloudEss
{
    internal class AuthRequest
    {
        [JsonPropertyName("user")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string HashedPassword { get; set; }
    }
}