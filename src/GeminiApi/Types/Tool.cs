using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Tool{
        [JsonPropertyName("functionDeclarations")]
        public FunctionDeclaration[]? FunctionDeclarations{get;set;}
        [JsonPropertyName("googleSearchRetrieval")]
        public GoogleSearchRetrieval? GoogleSearchRetrieval {get;set;}
        //public CodeExecutionResult? add https://ai.google.dev/api/caching#CodeExecution support later
    }
}