using KnowledgeAssistant.Console.Infrastructure.Chunking;

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
    }
}