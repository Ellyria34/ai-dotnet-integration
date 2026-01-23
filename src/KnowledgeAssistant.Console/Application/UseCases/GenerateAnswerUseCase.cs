using KnowledgeAssistant.Console.Application.Abstractions;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;

namespace KnowledgeAssistant.Console.Application.UseCases

{
public sealed class GenerateAnswerUseCase
{
    private readonly IRetriever _retriever;
    private readonly IAnswerGenerator _generator;

    public GenerateAnswerUseCase(IRetriever retriever, IAnswerGenerator generator)
    {
        _retriever = retriever;
        _generator = generator;
    }

    public async Task<string> ExecuteAsync(
        SearchQuery query,
        IEnumerable<KnowledgeChunk> knowledgeBase,
        CancellationToken cancellationToken = default)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        if (knowledgeBase == null)
        {
            throw new ArgumentNullException(nameof(knowledgeBase));
        }

        // 1. Retrieve relevant chunks
        var retrievedChunks = _retriever.Retrieve(query, knowledgeBase);

        // Guard clause (business decision)
        if (!retrievedChunks.Any())
            return "No relevant information found in the knowledge base.";

        // 2. Build the domain context
        var context = new RetrievedContext(retrievedChunks);

        // 3. Generate answer from context
        return await _generator.GenerateAsync(query, context, cancellationToken);
    }
}
}

