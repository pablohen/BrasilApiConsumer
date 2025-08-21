using System.Text.Json.Serialization;
using BrasilApiConsumer.Converters;

namespace BrasilApiConsumer.Models;

public class Cotacao
{
    [JsonPropertyName("paridade_compra")]
    public int ParidadeCompra { get; set; }

    [JsonPropertyName("paridade_venda")]
    public int ParidadeVenda { get; set; }

    [JsonPropertyName("cotacao_compra")]
    public decimal CotacaoCompra { get; set; }

    [JsonPropertyName("cotacao_venda")]
    public decimal CotacaoVenda { get; set; }

    [JsonPropertyName("data_hora_cotacao")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime DataHoraCotacao { get; set; }

    [JsonPropertyName("tipo_boletim")]
    public string TipoBoletim { get; set; } = string.Empty;
}
