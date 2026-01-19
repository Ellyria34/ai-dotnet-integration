namespace AssistantIT.Console.LLM;

public class OpenAiClient : ILLMClient
{
    // implémentation OpenAI ici
    public Task<string> CallAsync(string systemPrompt, string userPrompt, string functionSchemaJson)
    {
        throw new NotImplementedException();
    }
}
