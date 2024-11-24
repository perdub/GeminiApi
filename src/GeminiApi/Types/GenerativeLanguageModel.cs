using System.Collections.Generic;
using System.Text.Json.Serialization;

public class GenerativeLanguageModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; } = null;

    [JsonPropertyName("baseModelId")]
    public string? BaseModelId { get; set; } = null;

    [JsonPropertyName("version")]
    public string? Version { get; set; } = null;

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; } = null;

    [JsonPropertyName("description")]
    public string? Description { get; set; } = null;

    [JsonPropertyName("inputTokenLimit")]
    public int? InputTokenLimit { get; set; } = null;

    [JsonPropertyName("outputTokenLimit")]
    public int? OutputTokenLimit { get; set; } = null;

    [JsonPropertyName("supportedGenerationMethods")]
    public string[]? SupportedGenerationMethods { get; set; } = null;

    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; } = null;

    [JsonPropertyName("maxTemperature")]
    public double? MaxTemperature { get; set; } = null;

    [JsonPropertyName("topP")]
    public double? TopP { get; set; } = null;

    [JsonPropertyName("topK")]
    public int? TopK { get; set; } = null;
}