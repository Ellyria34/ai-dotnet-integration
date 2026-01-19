using AssistantIT.Console.Models;

namespace AssistantIT.Console.Observability
{
    public class AiIntentAnalysis
    {
        public UserIntent Intent { get; init; }
        public string? UserInput {get; init;}
        public string? Reason { get; init; }
    }
}
