// Hyperparameters.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Hyperparameters
    {
         [JsonPropertyName("learningRate")]
        public double? LearningRate { get; set; }

        [JsonPropertyName("learningRateMultiplier")]
        public double? LearningRateMultiplier { get; set; }

        [JsonPropertyName("epochCount")]
        public int? EpochCount { get; set; }

        [JsonPropertyName("batchSize")]
        public int? BatchSize { get; set; }
    }
}