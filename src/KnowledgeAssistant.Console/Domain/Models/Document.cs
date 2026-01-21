namespace KnowledgeAssistant.Domain.Models
{
    /// <summary>
    /// This class represents a raw knowledge document and exists to model a source of information before any processing or transformation occurs within the knowledge pipeline.
    /// </summary>
    public sealed class Document
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }

        /// <summary>
        /// Creates a new document instance.
        /// </summary>
        public Document(Guid id, string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Document title cannot be empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Document content cannot be empty.", nameof(content));

            Id = id;
            Title = title;
            Content = content;
        }
    }
}
