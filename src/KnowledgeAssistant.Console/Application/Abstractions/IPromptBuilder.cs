using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Application.Abstractions
{
    public interface IPromptBuilder
    {
        Prompt Build(
            SearchQuery query,
            RetrievedContext context);
    }
}
