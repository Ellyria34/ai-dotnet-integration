using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using OpenAI;
using OpenAI.Chat;

namespace KnowledgeAssistant.Console.Infrastructure.Generation
{
    public sealed class OpenAiAnswerGenerator : IAnswerGenerator
    {
        private readonly IPromptBuilder _promptBuilder;
        private readonly OpenAIClient _client;
        private readonly string _model;

        public OpenAiAnswerGenerator(
            IPromptBuilder promptBuilder,
            string apiKey,
            string model = "gpt-4o-mini")
        {
            _promptBuilder = promptBuilder
                ?? throw new ArgumentNullException(nameof(promptBuilder));

            _client = new OpenAIClient(apiKey);
            _model = model;
        }

        public async Task<GeneratedAnswer> GenerateAsync(
            SearchQuery query,
            RetrievedContext context,
            CancellationToken cancellationToken = default)
        {
            // 1. Build prompt
            Prompt prompt = _promptBuilder.Build(query, context);

            // 2. Get chat client
            var chatClient = _client.GetChatClient(_model);

            // 3. Call OpenAI with REAL SDK message types
            var response = await chatClient.CompleteChatAsync(
                new ChatMessage[]
                {
                    new SystemChatMessage(
                        "You are a helpful assistant. Answer strictly based on the provided context."),
                    new UserChatMessage(prompt.Content)
                },
                options: null,
                cancellationToken);

            // 4. Extract answer
            string content = response.Value.Content[0].Text;

            return new GeneratedAnswer(content);
        }
    }
}

