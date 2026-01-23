using KnowledgeAssistant.Console.Infrastructure.Generation;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Domain.Models;


namespace KnowledgeAssistant.Console.Tests.Generation
{
    public class LLMAnswerGeneratorTests
    {
        [Fact]
        public async Task GenerateAsync_ReturnsGeneratedAnswerContainingPrompt()
        {
            // Arrange
            var promptBuilder = new FakePromptBuilder();
            var generator = new LLMAnswerGenerator(promptBuilder);

            var query = new SearchQuery("RAG");
            var context = new RetrievedContext(new[]
            {
                new KnowledgeChunk(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "Some content")
            });

            // Act
            var answer = await generator.GenerateAsync(query, context);

            // Assert
            Assert.NotNull(answer);
            Assert.Contains("SIMULATED LLM ANSWER", answer.Content);
            Assert.Contains("FAKE PROMPT", answer.Content);
        }
    }
}
