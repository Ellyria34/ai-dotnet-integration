using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Infrastructure.Retrieval;

namespace KnowledgeAssistant.Console.Tests.Retrieval
{
    public class SimpleKeywordRetrieverTests
    {
        private readonly SimpleKeywordRetriever _retriever;

        public SimpleKeywordRetrieverTests()
        {
            _retriever = new SimpleKeywordRetriever();
        }
        
        [Fact]
        public void Retrieve_WhenQueryIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var chunks = new List<KnowledgeChunk>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                _retriever.Retrieve(null!, chunks).ToList());

        }

        [Fact]
        public void Retrieve_WhenChunksIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var query = new SearchQuery("Donne la définition de RAG");

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                _retriever.Retrieve(query, null!).ToList());

        }

        [Fact]
        public void Retrieve_WhenAllIsOk_ReturnPertinentChunk()
        {
            //Arrange
            var query = new SearchQuery("RAG signifie retrieval augmented generation");

            var matchingChunk = new KnowledgeChunk(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "RAG signifie retrieval augmented generation");

            var nonMatchingChunk = new KnowledgeChunk(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "ceci est un texte sans rapport avec la requête");

            var chunks = new List<KnowledgeChunk>
            {
                matchingChunk,
                nonMatchingChunk
            };

            //Act 
            var KnowledgeChunks = _retriever.Retrieve(query, chunks).ToList();
            
            // Assert
            Assert.Single(KnowledgeChunks);
            Assert.Equal("RAG signifie retrieval augmented generation", KnowledgeChunks[0].Content);
        }

        [Fact]
        public void Retrieve_WhenNoChunkMatches_ReturnsEmptyResult()
        {
            //Arrange
            var query = new SearchQuery("RAG signifie retrieval augmented generation");

            var matchingChunk = new KnowledgeChunk(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "ceci est un texte sans rapport avec la requête");

            var nonMatchingChunk = new KnowledgeChunk(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "ceci est un autres texte sans rapport avec la requête");

            var chunks = new List<KnowledgeChunk>
            {
                matchingChunk,
                nonMatchingChunk
            };

            //Act 
            var KnowledgeChunks = _retriever.Retrieve(query, chunks).ToList();
            
            // Assert
            Assert.Empty(KnowledgeChunks);
        }
    }
}