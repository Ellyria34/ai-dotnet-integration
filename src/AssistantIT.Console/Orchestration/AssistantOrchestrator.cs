using AssistantIT.Console.Intent;
using AssistantIT.Console.Support;
using AssistantIT.Console.Models;

namespace AssistantIT.Console.Orcherstration;

public class AssistantOrchestrator
{
    private readonly IIntentAnalyzer _intentAnalyser;
    private readonly SupportService _supportService;

    public AssistantOrchestrator()
    {
        _intentAnalyser = new SimpleIntentAnalyzer();
        _supportService = new SupportService();
    }

    public string HandleUserInput(string userInput)
    {
        var intent = _intentAnalyser.Analyze(userInput);
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