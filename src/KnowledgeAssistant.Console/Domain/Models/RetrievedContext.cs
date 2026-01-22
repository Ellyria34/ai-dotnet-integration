namespace KnowledgeAssistant.Console.Domain.Models
{
    /// <summary>
    /// This class represents the result of a retrieval operation
    /// and exists to explicitly separate information retrieval
    /// from answer generation in the knowledge pipeline.
    /// </summary>
    public sealed class RetrievedContext
    {
        /// <summary>
        /// Collection of knowledge chunks selected as relevant.
        /// </summary>
        public IReadOnlyCollection<KnowledgeChunk> Chunks { get; }

        /// <summary>
        /// Creates a new retrieved context instance.
        /// </summary>
        public RetrievedContext(IEnumerable<KnowledgeChunk> chunks)
        {
            if (chunks == null)
                throw new ArgumentNullException(nameof(chunks));

            var chunkList = chunks.ToList();

            if (!chunkList.Any())
                throw new ArgumentException(
                    "Retrieved context must contain at least one chunk.",
                    nameof(chunks));

            Chunks = chunkList.AsReadOnly();
        }
    }
}
