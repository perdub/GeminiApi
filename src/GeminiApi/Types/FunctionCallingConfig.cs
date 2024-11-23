using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class FunctionCallingConfig
    {
        [JsonPropertyName("mode")]
        public Mode Mode {get;set;}
        [JsonPropertyName("allowedFunctionNames")]
        public string[] AllowedFunctionNames{get;set;}

    }
}