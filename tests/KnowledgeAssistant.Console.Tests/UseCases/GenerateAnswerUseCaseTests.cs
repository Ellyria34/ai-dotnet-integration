using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.UseCases;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;


namespace KnowledgeAssistant.Console.Tests.UseCases
{
    public class GenerateAnswerUseCaseTests
    {
        [Fact]
        public async void ExecuteAsync_whenQueryIsNull_ReturnAgumentExeception()
        {
              // Arrange
            var retriever = new FakeRetrieverReturningEmpty();
            var generator = new FakeAnswerGenerator();
            var useCase = new GenerateAnswerUseCase(retriever, generator);

            var knowledgeBase = new List<KnowledgeChunk>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                useCase.ExecuteAsync(null!, knowledgeBase));
        }

        [Fact]
        public async void ExecuteAsync_WhenNoChunksAreFound_ReturnsInformationMessage()
        {
            // Arrange
            var query = new SearchQuery("RAG");
            var knowledgeBase = new List<KnowledgeChunk>();
            var retriever = new FakeRetrieverReturningEmpty();
            var generator = new FakeAnswerGenerator();
            var useCase = new GenerateAnswerUseCase(retriever, generator);

            //Act
            var answer = await useCase.ExecuteAsync(query, knowledgeBase);

            // Assert
            Assert.Equal("No relevant information found in the knowledge base.", answer);
        }

        [Fact]
        public async void ExecuteAsync_WhenChunksAreFound_ReturnsGeneratedAnswer()
        {
            // Arrange
            var query = new SearchQuery("RAG");
            var knowledgeBase = new List<KnowledgeChunk>();
            var retriever = new FakeRetrieverReturningChunks();
            var generator = new FakeAnswerGenerator();
            var useCase = new GenerateAnswerUseCase(retriever, generator);

            //Act
            var answer = await useCase.ExecuteAsync(query, knowledgeBase);

            // Assert
            Assert.Equal("RAG signifie Retrieval Augmented Generation", answer);
        }
    }
}