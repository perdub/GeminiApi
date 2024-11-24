using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Content
    {
        [JsonPropertyName("parts")]
        public Part[]? Parts{get;set;} = null;
        [JsonPropertyName("role")]
        public string? Role {get;set;} = null;
    }
}