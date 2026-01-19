using AssistantIT.Console.Intent.FunctionCalling;
using AssistantIT.Console.Models;
using Microsoft.VisualBasic;

namespace AssistantIT.Console.Intent;

public class AiIntentAnalyzer : IIntentAnalyzer
{
    string fuctionSchema = DetectedIntentFunctionSchema.Json;

    public UserIntent Analyze(string userInput)
    {
        DetectedIntentResponse detectedIntentResponse = new DetectedIntentResponse
        {
            Intent = UserIntent.Unknown
        };

        return detectedIntentResponse.Intent;
    }
}