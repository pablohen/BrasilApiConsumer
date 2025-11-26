using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class CptecCity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("estado")]
    public string Estado { get; set; } = string.Empty;
}
