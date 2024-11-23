using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class FunctionDeclaration
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("parameters")]
        public Schema Parameters { get; set; }
    }
}