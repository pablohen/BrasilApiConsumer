using System.Text.Json.Serialization;

namespace BrasilApiConsumer.Models;

public class Livro
{
    [JsonPropertyName("isbn")]
    public string Isbn { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; set; }

    [JsonPropertyName("authors")]
    public List<string> Authors { get; set; } = new();

    [JsonPropertyName("publisher")]
    public string Publisher { get; set; } = string.Empty;

    [JsonPropertyName("synopsis")]
    public string? Synopsis { get; set; }

    [JsonPropertyName("dimensions")]
    public BookDimensions? Dimensions { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("page_count")]
    public int? PageCount { get; set; }

    [JsonPropertyName("subjects")]
    public List<string> Subjects { get; set; } = new();

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("retail_price")]
    public object? RetailPrice { get; set; }

    [JsonPropertyName("cover_url")]
    public string? CoverUrl { get; set; }

    [JsonPropertyName("provider")]
    public string Provider { get; set; } = string.Empty;
}

public class BookDimensions
{
    [JsonPropertyName("width")]
    public double Width { get; set; }

    [JsonPropertyName("height")]
    public double Height { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;
}
