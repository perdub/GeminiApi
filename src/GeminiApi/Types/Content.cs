using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Content
    {
        [JsonPropertyName("parts")]
        public Part[] Parts;
        [JsonPropertyName("role")]
        public string? Role {get;set;} = null;
    }
}