using System.Text.Json.Serialization;

namespace GeminiApi.Types{
[JsonConverter(typeof(JsonStringEnumConverter))] 
public enum Modality
    {
        Unspecified,
        Text,
        Image,
        Video,
        Audio,
        Document
    }
    public class ModalityTokenCount
    {
        [JsonPropertyName("modality")]
        public Modality Modality { get; set; }

        [JsonPropertyName("tokenCount")]
        public int TokenCount { get; set; }
    }
}