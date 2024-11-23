using System.Text.Json.Serialization;

namespace GeminiApi.Types{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum Type{
        TYPE_UNSPECIFIED,
        STRING,
        NUMBER,
        INTEGER,
        BOOLEAN,
        ARRAY,
        OBJECT
    }
}