using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class DomainResponse
{
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("fqdn")]
    public string Fqdn { get; set; } = string.Empty;

    [JsonPropertyName("hosts")]
    public List<string>? Hosts { get; set; }

    [JsonPropertyName("publication-status")]
    public string? PublicationStatus { get; set; }

    [JsonPropertyName("expires-at")]
    public DateTime? ExpiresAt { get; set; }

    [JsonPropertyName("suggestions")]
    public List<string>? Suggestions { get; set; }
}
