using KnowledgeAssistant.Console.Infrastructure.Chunking;
using KnowledgeAssistant.Console.Domain.Models;
using Microsoft.VisualBasic;
using System.Text;


namespace KnowledgeAssistant.Console.Tests.Chunking
{
    public class SimpleChunkerTests
    {
        private const int ChunkSize = 5;
        private readonly SimpleChunker _chunker;

        public SimpleChunkerTests()
        {
            _chunker = new SimpleChunker(ChunkSize);
        }

        [Fact]
        public void SimpleChunker_WhenDocumentIsNull_ReturnException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _chunker.Chunk(null!).ToList());
        }

        [Fact]
        public void SimpleChunker_WhenDocumentLengthIsSmall_ReturnOneChunkWithSameContent()
        {
            //Arrange
            var documentId = Guid.NewGuid();
            Document document = new Document(documentId , "Title", "abc");

            //Act
            var chunks = _chunker.Chunk(document).ToList();

            //Assert
            Assert.Single(chunks);
            Assert.Equal("abc", chunks[0].Content);
            Assert.Equal(documentId, chunks[0].DocumentId);
        }

        [Fact]
        public void SimpleChunker_WhenContentLengthIsExactMultiple_ReturnsExpectedChunks()
        {
            //Arrange
            var documentId = Guid.NewGuid();
            Document document = new Document(documentId , "Title", "aaaaabbbbbccccc");
             List<string> expectedContentResult = ["aaaaa", "bbbbb", "ccccc"];

            //Act
            var chunks = _chunker.Chunk(document).ToList();

            //Assert
            Assert.Equal(3, chunks.Count);
            for(int i = 0; i<chunks.Count; i++)
            {
                Assert.Equal(expectedContentResult[i], chunks[i].Content);
                Assert.Equal(documentId, chunks[i].DocumentId);
            }
        }

        [Fact]
        public void SimpleChunker_WhenDocumentLengthIsNotMultiple_ReturnTheLastChunkWithSmallerLength()
        {
            //Arrange
            var documentId = Guid.NewGuid();
            Document document = new Document(documentId , "Title", "aaaaabbbbbcccccddd");
             List<string> expectedContentResult = ["aaaaa", "bbbbb", "ccccc","ddd"];

            //Act
            var chunks = _chunker.Chunk(document).ToList();

            //Assert
            Assert.Equal(4, chunks.Count);
            for(int i = 0; i<chunks.Count; i++)
            {
                Assert.Equal(expectedContentResult[i], chunks[i].Content);
                Assert.Equal(documentId, chunks[i].DocumentId);
            }
        }
    }
}