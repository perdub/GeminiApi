using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    // ... other classes and enums

    public class CitationMetadata
    {
        [JsonPropertyName("citationSources")]
        public List<CitationSource>? CitationSources { get; set; } = null;
    }

    public class CitationSource
    {
        [JsonPropertyName("startIndex")]
        public int? StartIndex { get; set; } = null;

        [JsonPropertyName("endIndex")]
        public int? EndIndex { get; set; } = null;

        [JsonPropertyName("uri")]
        public string? Uri { get; set; } = null;

        [JsonPropertyName("license")]
        public string? License { get; set; } = null;
    }
}