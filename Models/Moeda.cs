using System.Text.Json.Serialization;
using BrasilApiConsumer.Enums;

namespace BrasilApiConsumer.Models;

public class Moeda
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("simbolo")]
    public CurrencyCode Simbolo { get; set; }

    [JsonPropertyName("tipo_moeda")]
    public string TipoMoeda { get; set; } = string.Empty;
}
