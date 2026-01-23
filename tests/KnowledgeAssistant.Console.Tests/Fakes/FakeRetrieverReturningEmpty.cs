using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

    public sealed class FakeRetrieverReturningEmpty : IRetriever
    {
        public IEnumerable<KnowledgeChunk> Retrieve(
            SearchQuery query,
            IEnumerable<KnowledgeChunk> knowledgeBase)
        {
            return Enumerable.Empty<KnowledgeChunk>();
        }
    }