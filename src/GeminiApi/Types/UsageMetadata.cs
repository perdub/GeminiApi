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

        [JsonPropertyName("toolUsePromptTokenCount")]
        public int? ToolUsePromptTokenCount { get; set; } = null;

        [JsonPropertyName("thoughtsTokenCount")]
        public int? ThoughtsTokenCount { get; set; } = null;

        [JsonPropertyName("totalTokenCount")]
        public int? TotalTokenCount { get; set; } = null;

         [JsonPropertyName("promptTokensDetails")]
        public List<ModalityTokenCount> PromptTokensDetails { get; set; } = new List<ModalityTokenCount>();

        [JsonPropertyName("cacheTokensDetails")]
        public List<ModalityTokenCount> CacheTokensDetails { get; set; } = new List<ModalityTokenCount>();

        [JsonPropertyName("candidatesTokensDetails")]
        public List<ModalityTokenCount> CandidatesTokensDetails { get; set; } = new List<ModalityTokenCount>();

        [JsonPropertyName("toolUsePromptTokensDetails")]
        public List<ModalityTokenCount> ToolUsePromptTokensDetails { get; set; } = new List<ModalityTokenCount>();
    }
}