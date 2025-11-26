using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class ClimaCapital
{
    [JsonPropertyName("codigo_icao")]
    public string CodigoIcao { get; set; } = string.Empty;

    [JsonPropertyName("atualizado_em")]
    public string AtualizadoEm { get; set; } = string.Empty;

    [JsonPropertyName("pressao_atmosferica")]
    public string PressaoAtmosferica { get; set; } = string.Empty;

    [JsonPropertyName("visibilidade")]
    public string Visibilidade { get; set; } = string.Empty;

    [JsonPropertyName("vento")]
    public int Vento { get; set; }

    [JsonPropertyName("direcao_vento")]
    public int DirecaoVento { get; set; }

    [JsonPropertyName("umidade")]
    public int Umidade { get; set; }

    [JsonPropertyName("condicao")]
    public string Condicao { get; set; } = string.Empty;

    [JsonPropertyName("condicao_desc")]
    public string CondicaoDesc { get; set; } = string.Empty;

    [JsonPropertyName("temp")]
    public int Temp { get; set; }
}
