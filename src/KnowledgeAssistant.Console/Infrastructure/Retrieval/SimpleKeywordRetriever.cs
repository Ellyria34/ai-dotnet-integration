using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;


namespace KnowledgeAssistant.Console.Infrastructure.Retrieval
{
    /// <summary>
    /// Retrieves chunks by matching query keywords against chunk content.
    /// </summary>
    public sealed class SimpleKeywordRetriever : IRetriever
    {
        public IEnumerable<KnowledgeChunk> Retrieve(
            SearchQuery query,
            IEnumerable<KnowledgeChunk> chunks)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (chunks == null)
                throw new ArgumentNullException(nameof(chunks));

            IReadOnlyCollection<string> keywords = ExtractKeywords(query.Value);

        // Stream and return only chunks whose content matches
        // at least one keyword from the search query.
            foreach (KnowledgeChunk chunk in chunks)
            {
                if (ContainsAnyKeyword(chunk.Content, keywords))
                {
                    // Using yield return keeps the retrieval lazy and memory-efficient.
                    yield return chunk;
                }
            }
        }

        private static IReadOnlyCollection<string> ExtractKeywords(string queryText)
        {
            if (string.IsNullOrWhiteSpace(queryText))
                return Array.Empty<string>();

            return queryText
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.ToLowerInvariant())
                .ToArray();
        }

        private static bool ContainsAnyKeyword(
            string content,
            IReadOnlyCollection<string> keywords)
        {
            string lowerContent = content.ToLowerInvariant();

            foreach (string keyword in keywords)
            {
                if (lowerContent.Contains(keyword))
                    return true;
            }

            return false;
        }
    }
}
