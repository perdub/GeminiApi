using System.Text.Json.Serialization;

namespace GeminiApi.Types{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum Language{
        LANGUAGE_UNSPECIFIED,
        PYTHON
    }
}