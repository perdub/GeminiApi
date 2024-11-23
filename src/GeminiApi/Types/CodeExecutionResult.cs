using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class CodeExecutionResult
    {
        [JsonPropertyName("outcome")]
        public Outcome Outcome {get;set;}
        [JsonPropertyName("output")]
        public string Output{get;set;}

        public CodeExecutionResult(Outcome language, string output)
        {
            Outcome = language;
            Output = output;
        }
    }
}