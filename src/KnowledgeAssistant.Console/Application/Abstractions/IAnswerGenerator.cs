using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Domain.Models;

namespace KnowledgeAssistant.Console.Application.Abstractions
{
    public interface IAnswerGenerator
    {
        Task<string> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default);
    }
}
