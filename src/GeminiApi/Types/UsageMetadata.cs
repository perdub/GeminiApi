using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class UsageMetadata{
        [JsonPropertyName("totalTokenCount")]
        public int TotalTokenCount;
    }
}