using System.Text.Json.Serialization;

namespace AssistantIT.Console.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserIntent
{
    Unknown,
    AnalyzeTicket,
    AnalyzeLogs,
    ClarifyRequest
}
