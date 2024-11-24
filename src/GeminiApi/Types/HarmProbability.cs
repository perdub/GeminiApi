using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public enum HarmBlockThreshold
    {
        [JsonPropertyName("HARM_BLOCK_THRESHOLD_UNSPECIFIED")]
        HarmBlockThresholdUnspecified,

        [JsonPropertyName("BLOCK_LOW_AND_ABOVE")]
        BlockLowAndAbove,

        [JsonPropertyName("BLOCK_MEDIUM_AND_ABOVE")]
        BlockMediumAndAbove,

        [JsonPropertyName("BLOCK_ONLY_HIGH")]
        BlockOnlyHigh,

        [JsonPropertyName("BLOCK_NONE")]
        BlockNone,

        [JsonPropertyName("OFF")]
        Off
    }

    public enum HarmCategory
    {
        [JsonPropertyName("HARM_CATEGORY_UNSPECIFIED")]
        HarmCategoryUnspecified,

        [JsonPropertyName("HARM_CATEGORY_DEROGATORY")]
        Derogatory,

        [JsonPropertyName("HARM_CATEGORY_TOXICITY")]
        Toxicity,

        [JsonPropertyName("HARM_CATEGORY_VIOLENCE")]
        Violence,

        [JsonPropertyName("HARM_CATEGORY_SEXUAL")]
        Sexual,

        [JsonPropertyName("HARM_CATEGORY_MEDICAL")]
        Medical,

        [JsonPropertyName("HARM_CATEGORY_DANGEROUS")]
        Dangerous,

        [JsonPropertyName("HARM_CATEGORY_HARASSMENT")]
        Harassment,

        [JsonPropertyName("HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        [JsonPropertyName("HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        [JsonPropertyName("HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent,

        [JsonPropertyName("HARM_CATEGORY_CIVIC_INTEGRITY")]
        CivicIntegrity
    }

    public enum HarmProbability
    {
        [JsonPropertyName("HARM_PROBABILITY_UNSPECIFIED")]
        HarmProbabilityUnspecified,

        [JsonPropertyName("NEGLIGIBLE")]
        Negligible,

        [JsonPropertyName("LOW")]
        Low,

        [JsonPropertyName("MEDIUM")]
        Medium,

        [JsonPropertyName("HIGH")]
        High
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