namespace KnowledgeAssistant.Application.Abstractions
{
    public interface IKnowledgeSource
    {
        IEnumerable<Document> LoadDocuments();
    }
}
