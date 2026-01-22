using KnowledgeAssistant.Console.Domain.Models;

namespace KnowledgeAssistant.Console.Application.Abstractions
{
    public interface IKnowledgeSource
    {
        IEnumerable<Document> LoadDocuments();
    }
}
