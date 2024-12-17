using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
     // Enum for State
     [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum FileState
    {
        UNSPECIFIED = 0,
        PROCESSING = 1,
        ACTIVE = 2,
        FAILED = 3
    }


    public class Status
    {
        [JsonPropertyName("code")]
        public int? Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("details")]
        public List<object>? Details { get; set; }
    }


    public class VideoMetadata
    {
        [JsonPropertyName("videoDuration")]
        public string? VideoDuration { get; set; }
    }



    public class File
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; } = null;

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; } = null;

        [JsonPropertyName("mimeType")]
        public string? MimeType { get; set; } = null;

        [JsonPropertyName("sizeBytes")]
        public string? SizeBytes { get; set; } = null;

        /// <summary>
        /// get number size representation
        /// </summary>
        [JsonIgnore]
        public long Size{
            get{
                long a;
                if(long.TryParse(SizeBytes, out a)){
                    return a;
                }
                return 0;
            }
        }

        [JsonPropertyName("createTime")]
        public DateTime? CreateTime { get; set; } = null;

        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; } = null;

        [JsonPropertyName("expirationTime")]
        public DateTime? ExpirationTime { get; set; } = null;

        [JsonPropertyName("sha256Hash")]
        public string? Sha256Hash { get; set; } = null;

        [JsonPropertyName("uri")]
        public string? Uri { get; set; } = null;

        [JsonPropertyName("state")]
        public FileState? State { get; set; } = null;

        [JsonPropertyName("error")]
        public Status? Error { get; set; } = null;

        [JsonPropertyName("videoMetadata")]
        public VideoMetadata? VideoMetadata { get; set; } = null;
    }
}