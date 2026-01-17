using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public interface IIntentAnalyzer
{
    UserIntent Analyze(string userInput);
}
