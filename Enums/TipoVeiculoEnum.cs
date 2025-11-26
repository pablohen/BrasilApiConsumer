using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<TipoVeiculo>))]
public enum TipoVeiculo
{
    caminhoes,
    carros,
    motos,
}
