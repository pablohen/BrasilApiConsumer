using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Cotacoes
{
    [JsonPropertyName("cotacoes")]
    public List<Cotacao> ListaCotacoes { get; set; } = [];

    [JsonPropertyName("moeda")]
    public string Moeda { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public DateOnly Data { get; set; }
}
