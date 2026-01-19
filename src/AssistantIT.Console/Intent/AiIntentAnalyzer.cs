using AssistantIT.Console.Intent.FunctionCalling;
using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public class AiIntentAnalyzer : IIntentAnalyzer
{
    public UserIntent Analyze(string userInput)
    {
        DetectedIntentResponse detectedIntentResponse = new DetectedIntentResponse
        {
            Intent = UserIntent.Unknown
        };

        return detectedIntentResponse.Intent;
    }
}