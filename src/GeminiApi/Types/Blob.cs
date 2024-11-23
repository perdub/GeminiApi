using System.Text.Json.Serialization;

namespace GeminiApi.Types{
    public class Blob{
        [JsonPropertyName("mimeType")]
        public string MimeType{get;set;}
        [JsonPropertyName("data")]
        public string RawData {get;set;}

        public void DataFromByteArray(byte[] array){
            RawData = Convert.ToBase64String(array);
        }

        public Blob(string mimeType, string rawData)
        {
            MimeType = mimeType;
            RawData = rawData;
        }
        public Blob(string mimeType, byte[] array){
            MimeType = mimeType;
            DataFromByteArray(array);
        }
    }
}