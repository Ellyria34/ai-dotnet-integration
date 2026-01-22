using KnowledgeAssistant.Console.Domain.Models;

namespace KnowledgeAssistant.Console.Application.Abstractions
{
    public interface IChunker
    {
        IEnumerable<KnowledgeChunk> Chunk(Document document);
    }
}