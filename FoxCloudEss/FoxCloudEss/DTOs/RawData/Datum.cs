using System.Diagnostics;
using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.RawData
{
    [DebuggerDisplay("{Time} - {Value}")]
    public class Datum
    {
        [JsonPropertyName("time")] public string Time { get; set; }
        [JsonPropertyName("value")] public float Value { get; set; }

        [JsonIgnore]
        public DateTime ConvertedTime => Helper.ConvertTime(Time);
    }
}
