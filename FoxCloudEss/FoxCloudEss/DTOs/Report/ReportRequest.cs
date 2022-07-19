using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.Report
{
    internal class ReportRequest
    {
        [JsonPropertyName("deviceID")] public string DeviceId { get; set; }
        [JsonPropertyName("reportType")] public string ReportType { get; set; }
        [JsonPropertyName("variables")] public List<string> Variables { get; set; }
        [JsonPropertyName("queryDate")] public QueryDate QueryDate { get; set; }
    }
}
