using KnowledgeAssistant.Console.Application.UseCases;
using KnowledgeAssistant.Console.Application.Models;
using KnowledgeAssistant.Console.Domain.Models;
using KnowledgeAssistant.Console.Domain.ValueObjects;
using KnowledgeAssistant.Console.Infrastructure.Retrieval;
using KnowledgeAssistant.Console.Infrastructure.Generation;

var retriever = new SimpleKeywordRetriever();
var promptBuilder = new SimplePromptBuilder();

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
    ?? throw new InvalidOperationException("OPENAI_API_KEY not set");
    
// var generator = new FakeAnswerGenerator();
var answerGenerator = new OpenAiAnswerGenerator(promptBuilder, apiKey);

// var useCase = new GenerateAnswerUseCase(retriever, generator);
var useCase = new GenerateAnswerUseCase(retriever, answerGenerator);

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

var query = new SearchQuery("Quel temps fait il ?");
//var query = new SearchQuery("Que signifie RAG ?");

var answer = await useCase.ExecuteAsync(query, knowledgeBase);

Console.WriteLine(answer.Content);
