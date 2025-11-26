using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class PrevisaoOndas
{
    [JsonPropertyName("cidade")]
    public string Cidade { get; set; } = string.Empty;

    [JsonPropertyName("estado")]
    public string Estado { get; set; } = string.Empty;

    [JsonPropertyName("atualizado_em")]
    public string AtualizadoEm { get; set; } = string.Empty;

    [JsonPropertyName("ondas")]
    public List<OndaDia> Ondas { get; set; } = [];
}

public class OndaDia
{
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("dados_ondas")]
    public List<Onda> DadosOndas { get; set; } = [];
}

public class Onda
{
    [JsonPropertyName("vento")]
    public double Vento { get; set; }

    [JsonPropertyName("direcao_vento")]
    public string DirecaoVento { get; set; } = string.Empty;

    [JsonPropertyName("direcao_vento_desc")]
    public string DirecaoVentoDesc { get; set; } = string.Empty;

    [JsonPropertyName("altura_onda")]
    public double AlturaOnda { get; set; }

    [JsonPropertyName("direcao_onda")]
    public string DirecaoOnda { get; set; } = string.Empty;

    [JsonPropertyName("direcao_onda_desc")]
    public string DirecaoOndaDesc { get; set; } = string.Empty;

    [JsonPropertyName("agitacao")]
    public string Agitacao { get; set; } = string.Empty;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;
}
