using AssistantIT.Console.Models;
namespace AssistantIT.Console.Intent;

public class SimpleIntentAnalyzer : IIntentAnalyzer
{
    public UserIntent Analyze(string userInput)
    {
        // Placeholder implementation
        return UserIntent.Unknown;
    }
}
