using KnowledgeAssistant.Console.Infrastructure.Generation;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Tests.Generation
{
    public class SimplePromptBuilderTests
    {
        [Fact]
        public void Build_WhenCalled_ReturnsPromptContainingQueryAndContext()
        {
            // Arrange
            var builder = new SimplePromptBuilder();
            var query = new SearchQuery("RAG");
            var context = new RetrievedContext(new[]
            {
                new KnowledgeChunk(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "RAG signifie Retrieval Augmented Generation")
            });

            // Act
            var prompt = builder.Build(query, context);

            // Assert
            Assert.NotNull(prompt);
            Assert.Contains("RAG", prompt.Content);
            Assert.Contains("Retrieval Augmented Generation", prompt.Content);
        }
    }
}
