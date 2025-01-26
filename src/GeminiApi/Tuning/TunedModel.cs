// TunedModel.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class TunedModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; } = null;

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; } = null;

        [JsonPropertyName("description")]
        public string? Description { get; set; } = null;

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("createTime")]
        public string? CreateTime { get; set; } = null;

        [JsonPropertyName("updateTime")]
        public string? UpdateTime { get; set; } = null;

        [JsonPropertyName("tuningTask")]
        public TuningTask? TuningTask { get; set; } = null;

        [JsonPropertyName("readerProjectNumbers")]
        public string[]? ReaderProjectNumbers { get; set; } = null;

        /*[JsonPropertyName("tunedModelSource")]
        public TunedModelSource? TunedModelSource { get; set; } = null;*/

        [JsonPropertyName("baseModel")]
        public string? BaseModel { get; set; } = "models/gemini-1.5-flash-001-tuning";

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("topP")]
        public double? TopP { get; set; }

        [JsonPropertyName("topK")]
        public int? TopK { get; set; }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum State
    {
        STATE_UNSPECIFIED,
        CREATING,
        ACTIVE,
        FAILED
    }
}