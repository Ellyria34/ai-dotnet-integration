using AssistantIT.Console.Intent;
using AssistantIT.Console.Models;
using AssistantIT.Console.Tests.Fakes;
using Xunit;

public class AiIntentAnalyzerTests
{
    [Fact]
    public async Task AnalyzeAsync_WhenParsingIsNotImplemented_ReturnsUnknown()
    {
        // Arrange
        var fakeResponse = "{}";
        var llmClient = new FakeLLMClient(fakeResponse);
        var analyzer = new AiIntentAnalyzer(llmClient);

        // Act
        var result = await analyzer.AnalyzeAsync("test input");

        // Assert
        Assert.Equal(UserIntent.Unknown, result);
    }

    [Fact]
    public async Task AnalyzeAsync_WhenFunctionCallContainsAnalyzeLogs_ReturnsAnalyzeLogs()
    {
        // Arrange
        var openAiJsonResponse = """
        {
        "choices": [
            {
            "message": {
                "role": "assistant",
                "content": null,
                "function_call": {
                "name": "detect_user_intent",
                "arguments": "{ \"intent\": \"AnalyzeLogs\", \"reason\": \"User mentions log files\" }"
                }
            }
            }
        ]
        }
        """;

        var llmClient = new FakeLLMClient(openAiJsonResponse);
        var analyzer = new AiIntentAnalyzer(llmClient);

        // Act
        var result = await analyzer.AnalyzeAsync("please check the logs");

        // Assert
        Assert.Equal(UserIntent.AnalyzeLogs, result);
    }

    [Fact]
    public async Task AnalyzeAsync_WhenFunctionCallContainsAnalyzeTicket_ReturnsAnalyzeTicket()
    {
        //Arrange
        var openAiJsonResponse = """
                {
                "choices": [
                    {
                    "message": {
                        "role": "assistant",
                        "content": null,
                        "function_call": {
                        "name": "detect_user_intent",
                        "arguments": "{ \"intent\": \"AnalyzeTicket\", \"reason\": \"User mentions Ticket\" }"
                        }
                    }
                    }
                ]
                }
                """;

        var llmClient = new FakeLLMClient(openAiJsonResponse);
        var analyzer = new AiIntentAnalyzer(llmClient);

        //Act
        var result = await analyzer.AnalyzeAsync("please check ticket");

        //Assert
        Assert.Equal(UserIntent.AnalyzeTicket, result);

    }
}
