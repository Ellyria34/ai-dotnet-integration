using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Infrastructure.Generation
{
    public sealed class LLMAnswerGenerator : IAnswerGenerator
    {
        private readonly IPromptBuilder _promptBuilder;

        public LLMAnswerGenerator(IPromptBuilder promptBuilder)
        {
            _promptBuilder = promptBuilder 
                ?? throw new ArgumentNullException(nameof(promptBuilder));
        }

        public Task<GeneratedAnswer> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default)
            {
                // 1. Build prompt
                Prompt prompt = _promptBuilder.Build(query, context);

                // 2. Simulate LLM call (learning purpose)
                string llmRawResponse = SimulateLlmResponse(prompt);

                // 3. Parse & wrap result
                return Task.FromResult(new GeneratedAnswer(llmRawResponse));
            }

        private static string SimulateLlmResponse(Prompt prompt)
        {
            // Simulation volontairement simple
            return
                "[LLM ANSWER (with RAG included)]\n" +
                "Based on the provided context, here is the answer:\n\n" +
                prompt.Content;
        }
    }
}
