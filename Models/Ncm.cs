using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Ncm
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("data_inicio")]
    public string DataInicio { get; set; } = string.Empty;

    [JsonPropertyName("data_fim")]
    public string DataFim { get; set; } = string.Empty;

    [JsonPropertyName("tipo_ato")]
    public string TipoAto { get; set; } = string.Empty;

    [JsonPropertyName("numero_ato")]
    public string NumeroAto { get; set; } = string.Empty;

    [JsonPropertyName("ano_ato")]
    public string AnoAto { get; set; } = string.Empty;
}
