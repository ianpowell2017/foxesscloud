using System.Diagnostics;
using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.Report
{
    [DebuggerDisplay("{Variable}")]
    public class Result
    {
        [JsonPropertyName("variable")] public string Variable { get; set; }
        [JsonPropertyName("data")] public List<Datum> Data { get; set; }
    }
}
