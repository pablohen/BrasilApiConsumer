using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class DddResponse
{
    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("cities")]
    public List<string> Cities { get; set; } = [];
}
