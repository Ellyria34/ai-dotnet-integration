using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

public sealed class LLMAnswerGenerator : IAnswerGenerator
{
    private readonly IPromptBuilder _promptBuilder;

    public LLMAnswerGenerator(IPromptBuilder promptBuilder)
    {
        _promptBuilder = promptBuilder;
    }

    public Task<GeneratedAnswer> GenerateAsync(
        SearchQuery query,
        RetrievedContext context,
        CancellationToken cancellationToken = default)
    {
        Prompt prompt = _promptBuilder.Build(query, context);

        string llmRawResponse = SimulateLlmResponse(query, prompt);

        return Task.FromResult(new GeneratedAnswer(llmRawResponse));
    }

    private static string SimulateLlmResponse(SearchQuery query, Prompt prompt)
    {
        return
            $"[LLM ANSWER (with RAG included)]\n" +
            $"Request : {query}\n" +
            $"Response : {prompt.Content}";
    }
}
