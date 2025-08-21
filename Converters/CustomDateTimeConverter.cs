using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Converters;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string[] _formats =
    [
        "yyyy-MM-dd HH:mm:ss.fff",
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-ddTHH:mm:ss.fff",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-ddTHH:mm:ss.fffZ",
    ];

    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var value = reader.GetString();

        if (string.IsNullOrEmpty(value))
        {
            throw new JsonException("DateTime value is null or empty.");
        }

        foreach (var format in _formats)
        {
            if (
                DateTime.TryParseExact(
                    value,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result
                )
            )
            {
                return result;
            }
        }

        // Fallback to default parsing
        if (DateTime.TryParse(value, out var fallbackResult))
        {
            return fallbackResult;
        }

        throw new JsonException($"Unable to parse DateTime value: {value}");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(
            value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
        );
    }
}
