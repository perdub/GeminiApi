using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class GoogleSearchRetrieval
    {
        [JsonPropertyName("dynamicRetrievalConfig")]
        public DynamicRetrievalConfig DynamicRetrievalConfig{get;set;}
    }
}