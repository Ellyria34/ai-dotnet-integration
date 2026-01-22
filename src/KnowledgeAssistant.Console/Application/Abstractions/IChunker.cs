namespace KnowledgeAssistant.Application.Abstractions
{
    public interface IChunker
    {
        IEnumerable<KnowledgeChunk> Chunk(Document document);
    }
}