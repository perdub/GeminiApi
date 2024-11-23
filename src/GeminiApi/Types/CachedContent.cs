using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class CachedContent
    {
        [JsonPropertyName("contents")]
        public Content[] Contents {get;set;}
        [JsonPropertyName("tools")]
        public Tool[] Tools {get;set;}

        [JsonPropertyName("createTime")]
        public string? CreateTime {get;set;} = null;
        [JsonPropertyName("updateTime")]
        public string? UpdateTime {get;set;} = null;
        [JsonPropertyName("usageMetadata")]
        public UsageMetadata? UsageMetadata{get;set;} = null;

        [JsonPropertyName("expireTime")]
        public string? ExpireTime {get;set;} = null;
        [JsonPropertyName("ttl")]
        public string? TTL{get;set;} = null;

        [JsonPropertyName("name")]
        public string? Name{get;set;} = null;
        [JsonPropertyName("displayName")]
        public string? DisplayName{get;set;} = null;
        [JsonPropertyName("model")]
        public string? Model{get;set;} = null;

        [JsonPropertyName("systemInstruction")]
        public string? SystemInstruction{get;set;} = null;

        [JsonPropertyName("toolConfig")]
        public ToolConfig? ToolConfig{get;set;} = null;

    }
}