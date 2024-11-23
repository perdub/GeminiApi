using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class ToolConfig{
        [JsonPropertyName("functionCallingConfig")]
        public FunctionCallingConfig FunctionCallingConfig {get;set;}
    }
}