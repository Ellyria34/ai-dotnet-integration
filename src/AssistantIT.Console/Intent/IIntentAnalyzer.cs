using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public interface IIntentAnalyzer
{
    Task<UserIntent> AnalyzeAsync(string userInput);
}
