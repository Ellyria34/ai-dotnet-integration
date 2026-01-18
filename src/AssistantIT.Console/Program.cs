using AssistantIT.Console.Orchestration;

Console.WriteLine("Assistant IT Support - v1");
Console.WriteLine("Décris ton problème : ");

var userInput = Console.ReadLine() ?? string.Empty;

var orchestrator = new AssistantOrchestrator();
var response = orchestrator.HandleUserInput(userInput);

Console.WriteLine();
Console.WriteLine("Réponse de l'assistant :");
Console.WriteLine(response);