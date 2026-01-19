namespace AssistantIT.Console.LLM;

public interface ILLMClient
{
    Task<string> CallAsync(
        string systemPrompt,
        string userPrompt,
        string functionSchemaJson);
}