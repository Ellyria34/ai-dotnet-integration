using AssistantIT.Console.Intent.FunctionCalling;
using AssistantIT.Console.LLM;
using AssistantIT.Console.Models;

namespace AssistantIT.Console.Intent;

public class AiIntentAnalyzer : IIntentAnalyzer
{
    private readonly ILLMClient _llmClient;

    public AiIntentAnalyzer(ILLMClient llmClient)
    {
        _llmClient = llmClient;
    }

    public Task<UserIntent> Analyze(string userInput)
    {
        throw new NotImplementedException();
    }

    public async Task<UserIntent> AnalyzeAsync(string userInput)
    {
        var rawResponse = await _llmClient.CallAsync(
            IntentAnalysisPrompt.System,
            userInput,
            DetectedIntentFunctionSchema.Json
        );

        // TEMPORAIRE : parsing viendra après
        DetectedIntentResponse detectedIntentResponse = new DetectedIntentResponse
        {
            Intent = UserIntent.Unknown
        };

        return detectedIntentResponse.Intent;
    }
}
