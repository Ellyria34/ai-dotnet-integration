using AssistantIT.Console.Intent;
using AssistantIT.Console.LLM;
using AssistantIT.Console.Orchestration;
using AssistantIT.Console.Support;


Console.WriteLine("Assistant IT Support - v1");
Console.WriteLine("Décris ton problème : ");
var userInput = Console.ReadLine() ?? string.Empty;

// This decision is a configuration concern, not a business rule.
Console.WriteLine("Veux tu utiliser l'IA");
Console.WriteLine("Oui : 1, Non : 0");
var useIA = Console.ReadLine()?.Trim();

// We choose the concrete implementation at application startup.
IIntentAnalyzer intentAnalyzer;
var httpClient = new HttpClient();
var llmClient = new OpenAiClient(httpClient);

if(useIA == "1")
{
    // AI-based analyzer.
    intentAnalyzer = new AiIntentAnalyzer(llmClient);
}
else
{
    // Simple rule-based analyzer.
    intentAnalyzer = new SimpleIntentAnalyzer();
}

SupportService supportService  = new SupportService();

// All dependencies are explicitly provided here.
var orchestrator = new AssistantOrchestrator(intentAnalyzer, supportService);

// Execute the application flow.
var response = await orchestrator.HandleUserInputAsync(userInput);

Console.WriteLine();
Console.WriteLine("Réponse de l'assistant :");
Console.WriteLine(response);