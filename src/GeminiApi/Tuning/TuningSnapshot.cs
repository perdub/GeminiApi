// TuningSnapshot.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class TuningSnapshot
    {
        [JsonPropertyName("step")]
        public int Step { get; set; } = 1;

        [JsonPropertyName("epoch")]
        public int Epoch { get; set; } = 3;

        [JsonPropertyName("meanLoss")]
        public double MeanLoss { get; set; }

        [JsonPropertyName("computeTime")]
        public string? ComputeTime { get; set; } = null;
    }
}