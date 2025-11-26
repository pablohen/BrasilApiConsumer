using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Municipio
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("codigo_ibge")]
    public string CodigoIbge { get; set; } = string.Empty;
}
