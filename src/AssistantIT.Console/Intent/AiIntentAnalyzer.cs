using System.Text.Json;
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

    public async Task<UserIntent> AnalyzeAsync(string userInput)
    {
        var rawResponse = await _llmClient.CallAsync(
            IntentAnalysisPrompt.System,
            userInput,
            DetectedIntentFunctionSchema.Json
        );

        try
        {
            using var document = JsonDocument.Parse(rawResponse);

            var argumentsJson =
                document.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("function_call")
                    .GetProperty("arguments")
                    .GetString();

            if (string.IsNullOrWhiteSpace(argumentsJson))
                return UserIntent.Unknown;

            var detectedIntent =
                JsonSerializer.Deserialize<DetectedIntentResponse>(argumentsJson);

            return detectedIntent?.Intent ?? UserIntent.Unknown;
        }
        catch
        {
            return UserIntent.Unknown;
        }
    }
}