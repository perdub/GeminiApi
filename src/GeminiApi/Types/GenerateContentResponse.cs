using System.Text.Json.Serialization;

namespace GeminiApi.Types
{

    public class GenerateContentResponse
    {
        [JsonPropertyName("candidates")]
        public Candidate[]? Candidates { get; set; } = null;
        [JsonPropertyName("promptFeedback")]
        public PromptFeedback? PromptFeedback { get; set; } = null;
        [JsonPropertyName("usageMetadata")]
        public UsageMetadata? UsageMetadata { get; set; } = null;

    }
}