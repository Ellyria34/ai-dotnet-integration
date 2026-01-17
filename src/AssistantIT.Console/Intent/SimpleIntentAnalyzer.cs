using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public class SimpleIntentAnalyzer : IIntentAnalyzer
{
    public UserIntent Analyze(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
            return UserIntent.Unknown;

        if (userInput.Contains("log", StringComparison.OrdinalIgnoreCase))
            return UserIntent.AnalyzeLogs;

        if (userInput.Contains("ticket", StringComparison.OrdinalIgnoreCase))
            return UserIntent.AnalyzeTicket;
        return UserIntent.ClarifyRequest;
    }
}

