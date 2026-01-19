using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent.FunctionCalling;
public class DetectedIntentResponse
{
    public UserIntent Intent {get; init; }
    public string? Reason {get; init; }
}