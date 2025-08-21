using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Cotacoes
{
    [JsonPropertyName("cotacoes")]
    public List<Cotacao> ListaCotacoes { get; set; }

    [JsonPropertyName("moeda")]
    public string Moeda { get; set; }

    [JsonPropertyName("data")]
    public DateTime Data { get; set; }
}
