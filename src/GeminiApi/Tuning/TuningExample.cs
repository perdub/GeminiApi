// TuningExample.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class TuningExample
    {
        [JsonPropertyName("output")]
        public string? Output { get; set; } = null;

        [JsonPropertyName("textInput")]
        public string? TextInput { get; set; } = null;
    }
}