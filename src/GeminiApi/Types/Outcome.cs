using System.Text.Json.Serialization;

namespace GeminiApi.Types{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum Outcome{
        OUTCOME_UNSPECIFIED,
        OUTCOME_OK,
        OUTCOME_FAILED,
        OUTCOME_DEADLINE_EXCEEDED
    }
}