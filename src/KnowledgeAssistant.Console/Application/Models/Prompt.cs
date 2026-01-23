namespace KnowledgeAssistant.Console.Application.Models;

public sealed class Prompt
{
    public string Content { get; }

    public Prompt(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException(
                "Prompt content cannot be empty.",
                nameof(content));

        Content = content;
    }

    public override string ToString() => Content;
}
