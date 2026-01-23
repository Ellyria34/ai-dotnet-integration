using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using OpenAI;
using OpenAI.Chat;

public sealed class OpenAiAnswerGenerator : IAnswerGenerator
{
    private readonly IPromptBuilder _promptBuilder;
    private readonly OpenAIClient _client;
    private readonly string _model;

    public OpenAiAnswerGenerator(
        IPromptBuilder promptBuilder,
        string apiKey,
        string model = "gpt-4o-mini")
    {
        _promptBuilder = promptBuilder;
        _client = new OpenAIClient(apiKey);
        _model = model;
    }

    public async Task<GeneratedAnswer> GenerateAsync(
        SearchQuery query,
        RetrievedContext context,
        CancellationToken cancellationToken = default)
    {
        Prompt prompt = _promptBuilder.Build(query, context);

        var chatClient = _client.GetChatClient(_model);

        var response = await chatClient.CompleteChatAsync(
            new ChatMessage[]
            {
                new SystemChatMessage(
                    "You are an assistant answering questions strictly using the provided context."),
                new UserChatMessage(prompt.Content)
            },
            options: null,
            cancellationToken: cancellationToken);

        string content = response.Value.Content[0].Text.Trim();
        return new GeneratedAnswer(content);
    }
}
