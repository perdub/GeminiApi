using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class UsageMetadata{
        [JsonPropertyName("promptTokenCount")]
        public int? PromptTokenCount { get; set; } = null;

        [JsonPropertyName("cachedContentTokenCount")]
        public int? CachedContentTokenCount { get; set; } = null;

        [JsonPropertyName("candidatesTokenCount")]
        public int? CandidatesTokenCount { get; set; } = null;

        [JsonPropertyName("totalTokenCount")]
        public int? TotalTokenCount { get; set; } = null;
    }
}