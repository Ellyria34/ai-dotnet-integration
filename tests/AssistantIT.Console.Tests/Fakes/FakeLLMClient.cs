using AssistantIT.Console.LLM;

namespace AssistantIT.Console.Tests.Fakes;

public class FakeLLMClient : ILLMClient
{
    private readonly string _responseToReturn;

    public FakeLLMClient(string responseToReturn)
    {
        _responseToReturn = responseToReturn;
    }

    public Task<string> CallAsync(
        string systemPrompt,
        string userMessage,
        string functionSchemaJson)
    {
        return Task.FromResult(_responseToReturn);
    }
}
