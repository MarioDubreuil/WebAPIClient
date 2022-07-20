using System.Text.Json.Serialization;

namespace WebAPIClient;

internal class Repository
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
