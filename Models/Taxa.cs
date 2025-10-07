using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Taxa
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}
