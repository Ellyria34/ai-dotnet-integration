using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public class AiIntentAnalyzer : IIntentAnalyzer
{
    public UserIntent Analyze(string userInput)
    {
        return UserIntent.Unknown;
    }
    //TODO: Replace with LLM-based intent analysis using function calling”
}