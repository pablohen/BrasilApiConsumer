using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Moeda
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("simbolo")]
    public string Simbolo { get; set; }

    [JsonPropertyName("tipo_moeda")]
    public string TipoMoeda { get; set; }
}
