using System.Diagnostics;
using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.RawData
{
    [DebuggerDisplay("{Variable} - {Unit} - {Name}")]
    public class Result
    {
        [JsonPropertyName("variable")] public string Variable { get; set; }
        [JsonPropertyName("unit")] public string Unit { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("data")] public List<Datum> Data { get; set; }
    }
}
