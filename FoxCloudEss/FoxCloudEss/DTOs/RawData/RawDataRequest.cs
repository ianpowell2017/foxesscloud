using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.RawData
{
    internal class RawDataRequest
    {
        [JsonPropertyName("deviceID")] public string DeviceId { get; set; }
        [JsonPropertyName("variables")] public List<string> Variables { get; set; }
        [JsonPropertyName("timespan")] public string TimeSpan { get; set; }
        [JsonPropertyName("beginDate")] public BeginDate BeginDate { get; set; }
    }
}
