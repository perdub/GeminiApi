// TuningTask.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class TuningTask
    {
        [JsonPropertyName("startTime")]
        public string? StartTime { get; set; } = null;

        [JsonPropertyName("completeTime")]
        public string? CompleteTime { get; set; } = null;

        [JsonPropertyName("snapshots")]
        public TuningSnapshot[]? Snapshots { get; set; } = null;

        [JsonPropertyName("trainingData")]
        public Dataset? TrainingData { get; set; } = null;

        [JsonPropertyName("hyperparameters")]
        public Hyperparameters? Hyperparameters { get; set; } = null;
    }
}