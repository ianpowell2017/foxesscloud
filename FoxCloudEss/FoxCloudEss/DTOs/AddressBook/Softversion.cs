using System.Text.Json.Serialization;

namespace FoxCloudEss.DTOs.AddressBook
{
    public class Softversion
    {
        [JsonPropertyName("master")] public string Master { get; set; }
        [JsonPropertyName("slave")] public string Slave { get; set; }
        [JsonPropertyName("manager")] public string Manager { get; set; }
        [JsonPropertyName("afci")] public string Afci { get; set; }
    }
}
