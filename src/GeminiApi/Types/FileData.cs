using System.Text.Json.Serialization;

namespace GeminiApi.Types{
    public class FileData{
        [JsonPropertyName("mimeType")]
        public string? MimeType{get;set;} = null;
        [JsonPropertyName("fileUri")]
        public string? FileUri {get;set;} = null;

        public FileData()
        {
            
        }
        public FileData(string mimeType, string fileUri)
        {
            MimeType = mimeType;
            FileUri = fileUri;
        }
    }
}