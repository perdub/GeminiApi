using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class GenerateContentRequest
    {
        [JsonPropertyName("contents")]
        public Content[]? Contents { get; set; }

        [JsonPropertyName("tools")]
        public Tool[]? Tools { get; set; } =null;// Important: List type

        [JsonPropertyName("toolConfig")]
        public ToolConfig ToolConfig { get; set; }


        [JsonPropertyName("safetySettings")]
        public SafetySetting? SafetySettings { get; set; } = null;


        [JsonPropertyName("systemInstruction")]
        public Content SystemInstruction { get; set; } // Or Content instead of string

        [JsonPropertyName("generationConfig")]
        public GenerationConfig GenerationConfig { get; set; }

        [JsonPropertyName("cachedContent")]
        public string CachedContent { get; set; }
    }
}