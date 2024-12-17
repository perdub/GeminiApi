using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum HarmBlockThreshold
    {
        HARM_BLOCK_THRESHOLD_UNSPECIFIED,

        BLOCK_LOW_AND_ABOVE,

        BLOCK_MEDIUM_AND_ABOVE,

        BLOCK_ONLY_HIGH,

        BLOCK_NONE,

        OFF
    }
[JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum HarmCategory
    {
        HARM_CATEGORY_UNSPECIFIED,

        HARM_CATEGORY_DEROGATORY,

        HARM_CATEGORY_TOXICITY,

        HARM_CATEGORY_VIOLENCE,

        HARM_CATEGORY_SEXUAL,

        HARM_CATEGORY_MEDICAL,

        HARM_CATEGORY_DANGEROUS,

        HARM_CATEGORY_HARASSMENT,

        HARM_CATEGORY_HATE_SPEECH,

        HARM_CATEGORY_SEXUALLY_EXPLICIT,

        HARM_CATEGORY_DANGEROUS_CONTENT,

        HARM_CATEGORY_CIVIC_INTEGRITY
    }
[JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum HarmProbability
    {
        HARM_PROBABILITY_UNSPECIFIED,

        NEGLIGIBLE,

        LOW,

        MEDIUM,

        HIGH
    }

    public class SafetyRating
    {
        [JsonPropertyName("category")]
        public HarmCategory Category { get; set; }

        [JsonPropertyName("probability")]
        public HarmProbability Probability { get; set; }

        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }
    }

    public class SafetySetting
    {
        [JsonPropertyName("category")]
        public HarmCategory Category { get; set; }

        [JsonPropertyName("threshold")]
        public HarmBlockThreshold Threshold { get; set; }
    }
}