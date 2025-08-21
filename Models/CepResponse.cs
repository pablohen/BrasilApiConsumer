using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class CepResponse
{
    [JsonPropertyName("cep")]
    public string Cep { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("neighborhood")]
    public string Neighborhood { get; set; } = string.Empty;

    [JsonPropertyName("street")]
    public string Street { get; set; } = string.Empty;

    [JsonPropertyName("service")]
    public string Service { get; set; } = string.Empty;
}
