using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

public sealed class FakeRetrieverReturningChunks : IRetriever
{
    public IEnumerable<KnowledgeChunk> Retrieve(
        SearchQuery query,
        IEnumerable<KnowledgeChunk> knowledgeBase)
    {
        return new List<KnowledgeChunk>
        {
            new KnowledgeChunk(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "RAG signifie Retrieval Augmented Generation")
        };
    }
}
