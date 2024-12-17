using System.Text.Json.Serialization;
using GeminiApi.Types;

namespace GeminiApi.RAG.Types{

    public class EmbedContentRequest
    {
        [JsonPropertyName("model")]
        public string Model{get;set;} = "models/text-embedding-004";

        [JsonPropertyName("content")]
        public Content? Content{get;set;} = null;

        [JsonPropertyName("outputDimensionality")]
        public int OutputDimensionality{get;set;} = Vector.DEFAULT_VECTOR_SIZE;
    }

    public class EmbedContentResponse{
        [JsonPropertyName("embedding")]
        public Vector? Embedding{get;set;} = null;
    }
}