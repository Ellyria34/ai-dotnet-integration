using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

    public sealed class FakeAnswerGenerator : IAnswerGenerator
    {
        public Task<GeneratedAnswer> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default
        )
        {
            return Task.FromResult(new GeneratedAnswer("RAG signifie Retrieval Augmented Generation"));
        }
    }