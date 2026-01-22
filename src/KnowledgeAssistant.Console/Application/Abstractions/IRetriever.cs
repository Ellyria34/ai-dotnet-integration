using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Domain.Models;


namespace KnowledgeAssistant.Console.Application.Abstractions
{
    public interface IRetriever
    {
        IEnumerable<KnowledgeChunk> Retrieve(
            SearchQuery query,
            IEnumerable<KnowledgeChunk> chunks);
    }
}
