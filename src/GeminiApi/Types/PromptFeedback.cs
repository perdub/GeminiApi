using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    // ... other classes and enums

    public class PromptFeedback
    {
        [JsonPropertyName("blockReason")]
        public BlockReason? BlockReason { get; set; } = null;

        [JsonPropertyName("safetyRatings")]
        public List<SafetyRating>? SafetyRatings { get; set; } = null;
    }

    public enum BlockReason
    {
        [JsonPropertyName("BLOCK_REASON_UNSPECIFIED")]
        BlockReasonUnspecified,

        [JsonPropertyName("SAFETY")]
        Safety,

        [JsonPropertyName("OTHER")]
        Other,

        [JsonPropertyName("BLOCKLIST")]
        Blocklist,

        [JsonPropertyName("PROHIBITED_CONTENT")]
        ProhibitedContent
    }
}