namespace KnowledgeAssistant.Domain.Models
{
    /// <summary>
    /// This class represents a portion of a document content and 
    /// to model a unit of information derived from a document
    /// that can be independently processed by the knowledge pipeline.
    /// </summary>
    public sealed class KnowledgeChunk
    {
        public Guid Id { get; }
        
        //Identifier of the source document this chunk belongs to.
        public Guid DocumentId { get; }

        public string Content { get; }

        /// <summary>
        /// Creates a new knowledge chunk instance.
        /// </summary>
        public KnowledgeChunk(Guid id, Guid documentId, string content)
        {
            if (documentId == Guid.Empty)
                throw new ArgumentException("DocumentId cannot be empty.", nameof(documentId));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Chunk content cannot be empty.", nameof(content));

            Id = id;
            DocumentId = documentId;
            Content = content;
        }
    }
}
