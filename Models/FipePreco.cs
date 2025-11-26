using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class FipePreco
{
    [JsonPropertyName("valor")]
    public string Valor { get; set; } = string.Empty;

    [JsonPropertyName("marca")]
    public string Marca { get; set; } = string.Empty;

    [JsonPropertyName("modelo")]
    public string Modelo { get; set; } = string.Empty;

    [JsonPropertyName("anoModelo")]
    public int AnoModelo { get; set; }

    [JsonPropertyName("combustivel")]
    public string Combustivel { get; set; } = string.Empty;

    [JsonPropertyName("codigoFipe")]
    public string CodigoFipe { get; set; } = string.Empty;

    [JsonPropertyName("mesReferencia")]
    public string MesReferencia { get; set; } = string.Empty;

    [JsonPropertyName("tipoVeiculo")]
    public int TipoVeiculo { get; set; }

    [JsonPropertyName("siglaCombustivel")]
    public string SiglaCombustivel { get; set; } = string.Empty;

    [JsonPropertyName("dataConsulta")]
    public string DataConsulta { get; set; } = string.Empty;
}
