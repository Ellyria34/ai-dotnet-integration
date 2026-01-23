using System.Text;
using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Infrastructure.Generation
{
    public sealed class SimplePromptBuilder : IPromptBuilder
    {
        public Prompt Build(SearchQuery query, RetrievedContext context)
        {
            var sb = new StringBuilder();

            sb.AppendLine("You are an assistant answering questions using the provided context.");
            sb.AppendLine();
            sb.AppendLine("Context:");
            sb.AppendLine("--------");

            foreach (var chunk in context.Chunks)
            {
                sb.AppendLine(chunk.Content);
            }

            sb.AppendLine();
            sb.AppendLine("Question:");
            sb.AppendLine(query.Value);

            return new Prompt(sb.ToString());
        }
    }
}
