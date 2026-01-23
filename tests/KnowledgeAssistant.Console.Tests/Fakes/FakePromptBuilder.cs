using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Tests.Generation
{
    internal sealed class FakePromptBuilder : IPromptBuilder
    {
        public Prompt Build(SearchQuery query, RetrievedContext context)
            => new Prompt("SIMULATED LLM ANSWER");
    }
}
