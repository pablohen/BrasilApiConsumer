using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class FipeTabela
{
    [JsonPropertyName("codigo")]
    public int Codigo { get; set; }

    [JsonPropertyName("mes")]
    public string Mes { get; set; } = string.Empty;
}
