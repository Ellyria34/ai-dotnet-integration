namespace KnowledgeAssistant.Console.Domain.ValueObjects

{
    /// <summary>
    /// This value object represents a user search query 
    /// and exists to explicitly model a valid search intent within the domain.
    /// </summary>
    public sealed class SearchQuery
    {
        /// <summary>
        /// Raw textual value of the search query.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new search query instance.
        /// </summary>
        public SearchQuery(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Search query cannot be empty.", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;
    }
}
