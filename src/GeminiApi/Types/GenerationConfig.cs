using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    // ... (other classes and enums)

    public class GenerationConfig
    {
        [JsonPropertyName("stopSequences")]
        public List<string>? StopSequences { get; set; } = null;

        [JsonPropertyName("responseMimeType")]
        public string? ResponseMimeType { get; set; } = null;

        [JsonPropertyName("responseSchema")]
        public Schema? ResponseSchema { get; set; } = null; // Assuming you have a Schema class defined

        [JsonPropertyName("candidateCount")]
        public int? CandidateCount { get; set; } = null;

        [JsonPropertyName("maxOutputTokens")]
        public int? MaxOutputTokens { get; set; } = 8192;

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; } = null;

        [JsonPropertyName("topP")]
        public double? TopP { get; set; } = null;

        [JsonPropertyName("topK")]
        public int? TopK { get; set; } = null;

        [JsonPropertyName("presencePenalty")]
        public double? PresencePenalty { get; set; } = null;

        [JsonPropertyName("frequencyPenalty")]
        public double? FrequencyPenalty { get; set; } = null;


        [JsonPropertyName("responseLogprobs")]
        public bool? ResponseLogprobs { get; set; } = null;

        [JsonPropertyName("logprobs")]
        public int? Logprobs { get; set; } = null;

    }
}