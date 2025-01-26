// TuningExamples.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class TuningExamples
    {
        [JsonPropertyName("examples")]
        public TuningExample[]? Examples { get; set; } = null;
    }
}