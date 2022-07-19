using System.Diagnostics;
using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.Report
{
    [DebuggerDisplay("Hour: {Index} - {Value}")]
    public class Datum
    {
        [JsonPropertyName("index")] public int Index { get; set; }
        [JsonPropertyName("value")] public float Value { get; set; }
    }

}
