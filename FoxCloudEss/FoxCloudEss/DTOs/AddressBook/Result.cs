using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.AddressBook
{
    public class Result
    {
        [JsonPropertyName("deviceSN")] public string DeviceSerialNumber { get; set; }
        [JsonPropertyName("plantName")] public string PlantName { get; set; }
        [JsonPropertyName("moduleSN")] public string ModuleSerialNumber { get; set; }
        [JsonPropertyName("deviceType")] public string DeviceType { get; set; }
        [JsonPropertyName("status")] public int Status { get; set; }
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("countryCode")] public string CountryCode { get; set; }
        [JsonPropertyName("city")] public string City { get; set; }
        [JsonPropertyName("address")] public string Address { get; set; }
        [JsonPropertyName("feedinDate")] public string FeedinDate { get; set; }
        [JsonPropertyName("hardwareVersion")] public string HardwareVersion { get; set; }
        [JsonPropertyName("softVersion")] public Softversion SoftVersion { get; set; }
        [JsonPropertyName("protocolVersion")] public string ProtocolVersion { get; set; }
    }
}
