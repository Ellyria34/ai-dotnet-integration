using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public class SimpleIntentAnalyzer : IIntentAnalyzer
{
    public Task<UserIntent> AnalyzeAsync (string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
            return Task.FromResult(UserIntent.Unknown);

        if (userInput.Contains("log", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult(UserIntent.AnalyzeLogs);

        if (userInput.Contains("ticket", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult(UserIntent.AnalyzeTicket);

        return Task.FromResult(UserIntent.ClarifyRequest);
    }
}

