using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Corretora
{
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cep")]
    public string Cep { get; set; } = string.Empty;

    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; } = string.Empty;

    [JsonPropertyName("codigo_cvm")]
    public string CodigoCvm { get; set; } = string.Empty;

    [JsonPropertyName("complemento")]
    public string Complemento { get; set; } = string.Empty;

    [JsonPropertyName("data_inicio_situacao")]
    public string DataInicioSituacao { get; set; } = string.Empty;

    [JsonPropertyName("data_patrimonio_liquido")]
    public string DataPatrimonioLiquido { get; set; } = string.Empty;

    [JsonPropertyName("data_registro")]
    public string DataRegistro { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("logradouro")]
    public string Logradouro { get; set; } = string.Empty;

    [JsonPropertyName("municipio")]
    public string Municipio { get; set; } = string.Empty;

    [JsonPropertyName("nome_social")]
    public string NomeSocial { get; set; } = string.Empty;

    [JsonPropertyName("nome_comercial")]
    public string NomeComercial { get; set; } = string.Empty;

    [JsonPropertyName("pais")]
    public string Pais { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("telefone")]
    public string Telefone { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    [JsonPropertyName("valor_patrimonio_liquido")]
    public string ValorPatrimonioLiquido { get; set; } = string.Empty;
}
