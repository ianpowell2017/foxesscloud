using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs
{
    public class StandardResponse<T>
    {
        [JsonPropertyName("errno")]
        public int ErrorNumber { get; set; }
        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}