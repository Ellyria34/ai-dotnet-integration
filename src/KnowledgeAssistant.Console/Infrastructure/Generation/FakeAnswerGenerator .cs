using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Infrastructure.Generation
{
    public sealed class FakeAnswerGenerator : IAnswerGenerator
    {
        public Task<GeneratedAnswer> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default
        )
        {
            var content =
                "[FAKE LLM ANSWER]\n" +
                $"Question: {query.Value}\n" +
                $"Context size: {context.Chunks.Count}";

            return Task.FromResult(new GeneratedAnswer(content));
        }
    }
}
