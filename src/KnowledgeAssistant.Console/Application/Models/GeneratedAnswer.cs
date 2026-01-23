namespace KnowledgeAssistant.Console.Application.Models;

public sealed class GeneratedAnswer
{
    public string Content { get; }

    public GeneratedAnswer(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException(
                "Generated answer cannot be empty.",
                nameof(content));

        Content = content;
    }
}
