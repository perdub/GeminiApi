using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    // ... other classes and enums

    public class PromptFeedback
    {
        [JsonPropertyName("blockReason")]
        public BlockReason BlockReason { get; set; } = Types.BlockReason.None;

        [JsonPropertyName("safetyRatings")]
        public List<SafetyRating>? SafetyRatings { get; set; } = null;
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BlockReason
    {
        [JsonPropertyName("BLOCK_REASON_UNSPECIFIED")]
        BLOCK_REASON_UNSPECIFIED,

        [JsonPropertyName("SAFETY")]
        SAFETY,

        [JsonPropertyName("OTHER")]
        OTHER,

        [JsonPropertyName("BLOCKLIST")]
        BLOCKLIST,

        [JsonPropertyName("PROHIBITED_CONTENT")]

        PROHIBITED_CONTENT,
        
        None
    }
}