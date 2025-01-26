// Operation.cs
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Operation
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; } = null;

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; } = null;

        [JsonPropertyName("done")]
        public bool Done { get; set; }

        [JsonPropertyName("error")]
        public Status? Error { get; set; } = null;
        
        [JsonPropertyName("response")]
        public TuningResponse? Response {get;set;} = null;
    }

    public class Metadata
    {
        [JsonPropertyName("@type")]
        public string? Type { get; set; } = null;
    }
    public class TuningResponse
    {
        [JsonPropertyName("@type")]
        public string? Type{get;set;} = null;
    }
}