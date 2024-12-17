using System.Text.Json.Serialization;

namespace GeminiApi.RAG.Types
{
    class BatchEmbedContentsResponce
    {
        [JsonPropertyName("embeddings")]
        public Vector[]? Embeddings{get;set;} = null;
    }

    class BatchEmbedContentsRequest
    {
        [JsonPropertyName("requests")]
        public EmbedContentRequest[]? Requests{get;set;} = null;
    }
}