using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs
{
    internal class BeginDate : QueryDate
    {
        [JsonPropertyName("hour")] public string Hour { get; set; }
    }
}
