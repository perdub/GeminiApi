using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    // ... other classes and enums

    public class Candidate
    {
        [JsonPropertyName("content")]
        public Content? Content { get; set; } = null; // Assuming you have a Content class

        [JsonPropertyName("finishReason")]
        public FinishReason FinishReason { get; set; } = FinishReason.Stop;

        [JsonPropertyName("safetyRatings")]
        public List<SafetyRating>? SafetyRatings { get; set; } = null;

        [JsonPropertyName("citationMetadata")]
        public CitationMetadata? CitationMetadata { get; set; } = null;

        [JsonPropertyName("tokenCount")]
        public int? TokenCount { get; set; } = null;

        [JsonPropertyName("groundingAttributions")]
        public List<GroundingAttribution>? GroundingAttributions { get; set; } = null;

        [JsonPropertyName("groundingMetadata")]
        public GroundingMetadata? GroundingMetadata { get; set; } = null;

        [JsonPropertyName("avgLogprobs")]
        public double? AvgLogprobs { get; set; } = null;


        [JsonPropertyName("logprobsResult")]
        public LogprobsResult? LogprobsResult { get; set; } = null;

        [JsonPropertyName("index")]
        public int? Index { get; set; } = null;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum FinishReason
    {
        FinishReasonUnspecified,

        Stop,

        MAX_TOKENS,

        Safety,

        Recitation,

        Language,

        Other,


        Blocklist,

        ProhibitedContent,

        Spii,

        MalformedFunctionCall


    }

    public class GroundingAttribution
    {
        [JsonPropertyName("sourceId")]
        public AttributionSourceId? SourceId { get; set; } = null;

        [JsonPropertyName("content")]
        public Content? Content { get; set; } = null; // Assuming you have a Content class
    }

    public class AttributionSourceId
    {
        [JsonPropertyName("groundingPassage")]
        public GroundingPassageId? GroundingPassage { get; set; } = null;

        [JsonPropertyName("semanticRetrieverChunk")]
        public SemanticRetrieverChunk? SemanticRetrieverChunk { get; set; } = null;
    }

    public class GroundingPassageId
    {
        [JsonPropertyName("passageId")]
        public string? PassageId { get; set; } = null;

        [JsonPropertyName("partIndex")]
        public int? PartIndex { get; set; } = null;
    }

    public class SemanticRetrieverChunk
    {
        [JsonPropertyName("source")]
        public string? Source { get; set; } = null;

        [JsonPropertyName("chunk")]
        public string? Chunk { get; set; } = null;
    }

    public class GroundingMetadata
    {
        [JsonPropertyName("groundingChunks")]
        public List<GroundingChunk>? GroundingChunks { get; set; } = null;

        [JsonPropertyName("groundingSupports")]
        public List<GroundingSupport>? GroundingSupports { get; set; } = null;

        [JsonPropertyName("webSearchQueries")]
        public List<string>? WebSearchQueries { get; set; } = null;


        [JsonPropertyName("searchEntryPoint")]
        public SearchEntryPoint? SearchEntryPoint { get; set; } = null;

        [JsonPropertyName("retrievalMetadata")]
        public RetrievalMetadata? RetrievalMetadata { get; set; } = null;
    }


    public class SearchEntryPoint
    {

        [JsonPropertyName("renderedContent")]
        public string? RenderedContent { get; set; } = null;


        [JsonPropertyName("sdkBlob")]
        public string? SdkBlob { get; set; } = null;

    }

    public class GroundingChunk
    {
        [JsonPropertyName("web")]
        public Web? Web { get; set; } = null;
    }


    public class Web
    {
        [JsonPropertyName("uri")]
        public string? Uri { get; set; } = null;

        [JsonPropertyName("title")]
        public string? Title { get; set; } = null;
    }


    public class GroundingSupport
    {
        [JsonPropertyName("groundingChunkIndices")]
        public List<int>? GroundingChunkIndices { get; set; } = null;

        [JsonPropertyName("confidenceScores")]
        public List<double>? ConfidenceScores { get; set; } = null;


        [JsonPropertyName("segment")]
        public Segment? Segment { get; set; } = null;
    }


    public class Segment
    {
        [JsonPropertyName("partIndex")]
        public int? PartIndex { get; set; } = null;

        [JsonPropertyName("startIndex")]
        public int? StartIndex { get; set; } = null;


        [JsonPropertyName("endIndex")]
        public int? EndIndex { get; set; } = null;


        [JsonPropertyName("text")]
        public string? Text { get; set; } = null;
    }

    public class RetrievalMetadata
    {

        [JsonPropertyName("googleSearchDynamicRetrievalScore")]
        public double? GoogleSearchDynamicRetrievalScore { get; set; } = null;
    }


    public class LogprobsResult
    {
        [JsonPropertyName("topCandidates")]
        public List<TopCandidates>? TopCandidates { get; set; } = null;

        [JsonPropertyName("chosenCandidates")]
        public List<Candidate>? ChosenCandidates { get; set; } = null; // This refers back to the main Candidate class
    }


    public class TopCandidates
    {

        [JsonPropertyName("candidates")]
        public List<LogprobeCandidate>? Candidates { get; set; } = null; // Using Candidate2 to avoid ambiguity
    }

    public class LogprobeCandidate  // Renamed to avoid conflict with the main Candidate class
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; } = null;

        [JsonPropertyName("tokenId")]
        public int? TokenId { get; set; } = null;


        [JsonPropertyName("logProbability")]
        public double? LogProbability { get; set; } = null;
    }




}