using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

    public sealed class FakeAnswerGenerator : IAnswerGenerator
    {
        public Task<string> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult("RAG signifie Retrieval Augmented Generation");
        }
    }