using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Application.Abstractions;

namespace KnowledgeAssistant.Console.Infrastructure.generation
{
    public sealed class FakeAnswerGenerator : IAnswerGenerator
    {
        public Task<string> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                $"[FAKE LLM ANSWER]\n" + 
                $"Question: {query.Value}\n" +
                $"Context size: {context.Chunks.Count}");
        }
    }
}
