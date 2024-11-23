using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Mode
    {
        MODE_UNSPECIFIED,
        AUTO,
        ANY,
        NONE
    }
}