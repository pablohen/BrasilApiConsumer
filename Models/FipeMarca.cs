using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class FipeMarca
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public string Valor { get; set; } = string.Empty;
}
