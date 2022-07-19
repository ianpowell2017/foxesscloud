using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs
{
    internal class QueryDate
    {
        [JsonPropertyName("year")] public string Year { get; set; }
        [JsonPropertyName("month")] public string Month { get; set; }
        [JsonPropertyName("day")] public string Day { get; set; }
    }
}
