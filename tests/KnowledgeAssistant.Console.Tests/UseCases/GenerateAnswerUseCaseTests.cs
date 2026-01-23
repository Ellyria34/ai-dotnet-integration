using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Application.UseCases;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;


namespace KnowledgeAssistant.Console.Tests.UseCases
{
    public class GenerateAnswerUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_whenQueryIsNull_ReturnAgumentExeception()
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
        public async Task ExecuteAsync_WhenNoChunksAreFound_ReturnsInformationMessage()
        {
            // Arrange
            var query = new SearchQuery("RAG");
            var knowledgeBase = new List<KnowledgeChunk>();
            var retriever = new FakeRetrieverReturningEmpty();
            var generator = new FakeAnswerGenerator();
            var useCase = new GenerateAnswerUseCase(retriever, generator);

            //Act
            var answer = await useCase.ExecuteAsync(query, knowledgeBase, default);

            // Assert
            Assert.Equal(
                $"[LLM ANSWER (with RAG included)]\n" +
                $"Request : {query}\n" + 
                "We Cant'n display response because no relevant information found in the knowledge base.", 
                answer.Content
            );
        }

        [Fact]
        public async Task ExecuteAsync_WhenChunksAreFound_ReturnsGeneratedAnswer()
        {
            // Arrange
            var query = new SearchQuery("RAG");
            var knowledgeBase = new List<KnowledgeChunk>();
            var retriever = new FakeRetrieverReturningChunks();
            var generator = new FakeAnswerGenerator();
            var useCase = new GenerateAnswerUseCase(retriever, generator);

            //Act
            var answer = await useCase.ExecuteAsync(query, knowledgeBase, default);

            // Assert
            Assert.Equal(
                $"[LLM ANSWER (with RAG included)]\n" +
                $"Request : {query}\n" + 
                $"Response : RAG signifie Retrieval Augmented Generation", 
                answer.Content
            );
        }
    }
}