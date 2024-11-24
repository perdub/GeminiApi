using System.Text.Json.Serialization;

public class ListModelsResponse
{
    [JsonPropertyName("models")]
    public GenerativeLanguageModel[]? Models { get; set; } = null;

    [JsonPropertyName("nextPageToken")]
    public string? NextPageToken { get; set; } = null;
}