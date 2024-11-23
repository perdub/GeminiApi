using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Schema{
        [JsonPropertyName("type")]
        public Type Type{get;set;}
        [JsonPropertyName("format")]
        public string? Format{get;set;} = null;
        [JsonPropertyName("description")]
        public string? Description{get;set;} = null;
        [JsonPropertyName("nullable")]
        public bool? Nullable {get;set;} = null;
        [JsonPropertyName("enum")]
        public string? EnumArray {get;set;} = null;

        [JsonPropertyName("maxItems")]
        public string? MaxItems {get;set;} = null;
        [JsonPropertyName("minItems")]
        public string? MinItems {get;set;} = null;

        [JsonPropertyName("properties")]
        public Dictionary<string, Schema>? Properties{get;set;} = null;

        [JsonPropertyName("required")]
        public string? Required{get;set;} = null;

        [JsonPropertyName("items")]
        public Schema? Items{get;set;} = null;
    }
}