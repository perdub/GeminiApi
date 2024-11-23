using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class DynamicRetrievalConfig
    {
        [JsonPropertyName("mode")]
        public SearchPredictorMode Mode{get;set;}
        [JsonPropertyName("dynamicThreshold")]
        public int DynamicThreshold{get;set;}
    }
}