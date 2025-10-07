using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class PixParticipant
{
    [JsonPropertyName("ispb")]
    public string Ispb { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("nome_reduzido")]
    public string NomeReduzido { get; set; } = string.Empty;

    [JsonPropertyName("modalidade_participacao")]
    public string ModalidadeParticipacao { get; set; } = string.Empty;

    [JsonPropertyName("tipo_participacao")]
    public string TipoParticipacao { get; set; } = string.Empty;

    [JsonPropertyName("inicio_operacao")]
    public DateTime InicioOperacao { get; set; }
}
