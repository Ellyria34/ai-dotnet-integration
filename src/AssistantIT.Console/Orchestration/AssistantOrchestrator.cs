using AssistantIT.Console.Intent;
using AssistantIT.Console.Support;
using AssistantIT.Console.Models;

namespace AssistantIT.Console.Orchestration;

public class AssistantOrchestrator
{
    private readonly IIntentAnalyzer _intentAnalyzer;
    private readonly SupportService _supportService;

    // Default constructor used in production.
    // It delegates to the injectable constructor with real implementations.
    public AssistantOrchestrator() : this(new SimpleIntentAnalyzer(), new SupportService())
    {
    }

    // Injectable constructor used for testing.
    public AssistantOrchestrator(IIntentAnalyzer intentAnalyzer, SupportService supportService)
    {
         _intentAnalyzer = intentAnalyzer;
         _supportService = supportService;
    }

    public async Task<string> HandleUserInputAsync(string userInput)
    {
        var intent = await _intentAnalyzer.AnalyzeAsync(userInput);
        string response;
        switch (intent)
        {
            case UserIntent.AnalyzeTicket:
                response = _supportService.HandleTicket(userInput);
                break;

            case UserIntent.AnalyzeLogs:
                response = _supportService.HandleLogs(userInput);
                break;

            case UserIntent.ClarifyRequest:
                response = "Peux-tu préciser ton problème ou fournir plus de détails ?";
                break;

            default:
                response = "Je n’ai pas compris la demande. Peux-tu reformuler ?";
                break;
        }

        return response;
    }
}