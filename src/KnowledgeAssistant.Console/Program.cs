using KnowledgeAssistant.Console.Application.UseCases;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Infrastructure.Retrieval;
using KnowledgeAssistant.Console.Infrastructure.generation;

var retriever = new SimpleKeywordRetriever();
var generator = new FakeAnswerGenerator();

var useCase = new GenerateAnswerUseCase(retriever, generator);

// Fake knowledge base (normally produced by chunking)
var knowledgeBase = new List<KnowledgeChunk>
{
    new KnowledgeChunk(
        Guid.NewGuid(),
        Guid.NewGuid(),
        "RAG signifie Retrieval Augmented Generation"),

    new KnowledgeChunk(
        Guid.NewGuid(),
        Guid.NewGuid(),
        "Ce texte ne contient aucune information pertinente")
};

var query = new SearchQuery("RAG");

var answer = await useCase.ExecuteAsync(query, knowledgeBase);

Console.WriteLine(answer);
