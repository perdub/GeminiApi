
using GeminiApi.Types;

namespace GeminiApi.RAG.Tests;

public class TunedModelSourceSerializationTests(ITestOutputHelper output)
{
    [Theory]
    [MemberData(nameof(testData1))]
    public void Serialization(string? tunedModel, string? baseModel){
        
        TunedModelSource q = new TunedModelSource{
            TunedModel = tunedModel,
            BaseModel = baseModel
        };

        string json = System.Text.Json.JsonSerializer.Serialize<TunedModelSource>(q);

        output.WriteLine(json);

        Assert.NotNull(json);
        Assert.NotEmpty(json);
    }

    public static IEnumerable<object[]> testData1(){
        foreach(var tunedModel in new string[]{"model.1", null, "MyTunedModel001"}){
            foreach(var baseModel in new string[]{"gemini-1.5-flash-001", "baseModel"}){
                yield return new object[]{tunedModel, baseModel};
            }
        }
    }

    [Theory]
    [MemberData(nameof(testData2))]
    public void Deserialization(string json)
    {

        var res =  System.Text.Json.JsonSerializer.Deserialize<TunedModelSource>(json);
        
        Assert.NotNull(res);

        output.WriteLine($"Base model: {res.BaseModel}");
        output.WriteLine($"Tuned model: {res.TunedModel}");
    }

    public static IEnumerable<object[]> testData2(){
        string[] jsons = new string[]{
            "{\"tunedModelSource\": {  \"tunedModel\": null, \"baseModel\": \"baseModel\"}}",
            "{\"baseModel\": \"baseModel\"}"
        };
        foreach(var tunedModel in jsons){
                yield return new object[]{tunedModel};
        }
    }
}
