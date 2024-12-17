using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Content
    {
        [JsonPropertyName("parts")]
        public Part[]? Parts{get;set;} = null;
        [JsonPropertyName("role")]
        public string? Role {get;set;} = null;

        /// <summary>
        /// try to add new part object in content
        /// </summary>
        /// <param name="part"></param>
        public void AutoAdd(Part part){
            Part[] newArr = new Part[Parts?.Length+1 ?? 1];
            if(Parts != null){
                Array.Copy(Parts, newArr, Parts.Length);
                newArr[Parts.Length] = part;
            }
            else{
                newArr[0]=part;
            }
            Parts = newArr;
        }
    }
}