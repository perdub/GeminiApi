using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Part{
        [JsonPropertyName("text")]
        public string? Text{get;set;} = null;

        [JsonPropertyName("inlineData")]
        public Blob? InlineData{get;set;} = null;

     /*  todo: add functionCall support [JsonPropertyName("text")]
        public Func? Text{get;set;} = null; */

        [JsonPropertyName("fileData")]
        public FileData? FileData{get;set;} = null;

        
        [JsonPropertyName("executableCode")]
        public ExecutableCode? ExecutableCode{get;set;} = null;
        
        [JsonPropertyName("codeExecutionResult")]
        public CodeExecutionResult? CodeExecutionResult{get;set;} = null;

        
    }
}