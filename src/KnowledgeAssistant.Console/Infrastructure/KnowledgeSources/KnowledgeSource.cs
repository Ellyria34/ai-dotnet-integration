using KnowledgeAssistant.Console.Application.Abstractions;

namespace KnowledgeAssistant.Console.Domain.Models
{
    /// <summary>
    /// Loads knowledge documents from text files located in a directory.
    /// </summary>
    public sealed class KnowledgeSource : IKnowledgeSource
    {
        private readonly string _directoryPath;

        public KnowledgeSource(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException("Directory path cannot be empty.", nameof(directoryPath));

            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException(
                    $"Knowledge directory not found: {directoryPath}");

            _directoryPath = directoryPath;
        }

        public IEnumerable<Document> LoadDocuments()
        {
            var files = Directory.GetFiles(_directoryPath, "*.*", SearchOption.TopDirectoryOnly);

            foreach (var filePath in files)
            {
                var extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (extension != ".txt" && extension != ".md")
                    continue;

                var content = File.ReadAllText(filePath);
                var title = Path.GetFileNameWithoutExtension(filePath);

                // Yield documents one by one to avoid loading all files into memory at once.
                // This allows lazy enumeration and keeps the ingestion process lightweight.
                yield return new Document(
                    Guid.NewGuid(),
                    title,
                    content);
            }
        }
    }
}
