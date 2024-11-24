using System.Text;
using System.Text.Json;

namespace GeminiApi
{
    public static class JsonSerializer
    {
        public static JsonSerializerOptions Options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
#if DEBUG
            WriteIndented = true
#endif
        };

        public static string Serialize<T>(this T obj)
        {
            return System.Text.Json.JsonSerializer.Serialize<T>(obj, Options);
        }

        public static T? Deserialize<T>(this string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json, Options);
        }
    }
}