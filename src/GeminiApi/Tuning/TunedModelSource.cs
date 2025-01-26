// TunedModelSource.cs
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    /// <summary>
    /// Because in https://ai.google.dev/api/tuning#method:-tunedmodels.create says that source_model can be only one of the following: tunedModelSource, baseModel, you should use this class. if you need work with base model, just set it, if you need `tunedModelSource`, add value to `TunedModel`
    /// </summary>
    [JsonConverter(typeof(TunedModelSourceJsonConverter))]
    public class TunedModelSource
    {
        [JsonPropertyName("tunedModel")]
        public string? TunedModel { get; set; } = null;

        [JsonPropertyName("baseModel")]
        public string? BaseModel { get; set; } = null;
    }

    public class TunedModelSourceJsonConverter : JsonConverter<TunedModelSource>
    {
        public override TunedModelSource? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            int depth = 1;

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                string? tunedModel = null;
                string? baseModel = null;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        depth--;
                        if(depth == 0){
                            break;
                        }
                    }
                    if(reader.TokenType == JsonTokenType.StartObject){
                        depth++;
                    }

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string propertyName = reader.GetString();
                        if (propertyName == "tunedModel")
                        {
                            reader.Read();
                            tunedModel = reader.GetString();
                        }
                        else if (propertyName == "baseModel")
                        {
                            reader.Read();
                            baseModel = reader.GetString();
                        }
                    }
                }


                return new TunedModelSource
                {
                    TunedModel = tunedModel,
                    BaseModel = baseModel
                };

            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                string? baseModel = reader.GetString();
                return new TunedModelSource
                {
                    BaseModel = baseModel
                };
            }
            throw new JsonException("Fall to deserialize TunedModelSource");
        }

        public override void Write(Utf8JsonWriter writer, TunedModelSource value, JsonSerializerOptions options)
        {
            if (!string.IsNullOrWhiteSpace(value.TunedModel))
            {
                writer.WriteStartObject("tunedModelSource");
                writer.WriteString("tunedModel", value.TunedModel);
                writer.WriteString("baseModel", value.BaseModel);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteString("baseModel", value.BaseModel);
            }
        }

    }
}