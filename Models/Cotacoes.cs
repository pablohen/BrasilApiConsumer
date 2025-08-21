using System.Text.Json.Serialization;
using BrasilApiConsumer.Enums;

namespace BrasilApiConsumer.Models;

public class Cotacoes
{
    [JsonPropertyName("cotacoes")]
    public List<Cotacao> ListaCotacoes { get; set; } = [];

    [JsonPropertyName("moeda")]
    public CurrencyCode Moeda { get; set; }

    [JsonPropertyName("data")]
    public DateOnly Data { get; set; }
}
