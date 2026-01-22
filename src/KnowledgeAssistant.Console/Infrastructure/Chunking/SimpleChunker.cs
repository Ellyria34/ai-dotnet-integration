namespace KnowledgeAssistant.Infrastructure.Chunking
{
    /// <summary>
    /// Splits a document into fixed-size text chunks.
    /// </summary>
    public sealed class SimpleChunker : IChunker
    {
        private readonly int _chunkSize;

        public SimpleChunker(int chunkSize)
        {
            if (chunkSize <= 0)
                throw new ArgumentException("Chunk size must be greater than zero.", nameof(chunkSize));

            _chunkSize = chunkSize;
        }

        public IEnumerable<KnowledgeChunk> Chunk(Document document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            var content = document.Content;

            for (int i = 0; i < content.Length; i += _chunkSize)
            {
                var length = Math.Min(_chunkSize, content.Length - i);
                var chunkContent = content.Substring(i, length);

                yield return new KnowledgeChunk(
                    Guid.NewGuid(),
                    document.Id,
                    chunkContent);
            }
        }
    }
}
