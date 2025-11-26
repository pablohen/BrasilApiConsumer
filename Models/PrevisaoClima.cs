using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class PrevisaoClima
{
    [JsonPropertyName("cidade")]
    public string Cidade { get; set; } = string.Empty;

    [JsonPropertyName("estado")]
    public string Estado { get; set; } = string.Empty;

    [JsonPropertyName("atualizado_em")]
    public string AtualizadoEm { get; set; } = string.Empty;

    [JsonPropertyName("clima")]
    public List<Clima> Clima { get; set; } = [];
}

public class Clima
{
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("condicao")]
    public string Condicao { get; set; } = string.Empty;

    [JsonPropertyName("condicao_desc")]
    public string CondicaoDesc { get; set; } = string.Empty;

    [JsonPropertyName("min")]
    public int Min { get; set; }

    [JsonPropertyName("max")]
    public int Max { get; set; }

    [JsonPropertyName("indice_uv")]
    public int IndiceUv { get; set; }
}
