using System.Text.Json.Serialization;
using AssistantIT.Console.Models;

public class DetectedIntentResponse
{
    [JsonPropertyName("intent")]
    public UserIntent Intent { get; init; }

    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
