using System.Text;
using GeminiApi.Types;

namespace GeminiApi
{
    public static class HttpHelper
    {
        public static HttpContent PackToHttpContent(this GenerateContentRequest generateContentRequest){
            HttpContent httpContent = new StringContent(generateContentRequest.Serialize(), Encoding.UTF8);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return httpContent;
        }

        public async static Task<GenerateContentResponse?> UnpackReturn(this HttpResponseMessage httpResponseMessage){
            var str = await httpResponseMessage.Content.ReadAsStringAsync();
            var ob = str.Deserialize<GenerateContentResponse>();
            return ob;
        }

        public static string? FastResultExtract(this GenerateContentResponse response){
            return response.Candidates[0].Content.Parts[0].Text;
        }
    }
}