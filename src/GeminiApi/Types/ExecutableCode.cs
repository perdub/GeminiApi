using System.Text.Json.Serialization;

namespace GeminiApi.Types{
    public class ExecutableCode{
        [JsonPropertyName("language")]
        public Language Language {get;set;}
        [JsonPropertyName("code")]
        public string Code{get;set;}

        public ExecutableCode(Language language, string code)
        {
            Language = language;
            Code = code;
        }
    }
}