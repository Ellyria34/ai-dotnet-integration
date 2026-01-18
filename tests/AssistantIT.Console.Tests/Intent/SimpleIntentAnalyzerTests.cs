using System.Reflection;
using AssistantIT.Console.Intent;
using AssistantIT.Console.Models;
using Xunit;

namespace AssistantIT.Console.Tests.Intent
{
    public class SimpleIntentAnalyzerTests
    {
        [Theory]
        [InlineData("Erreur détectée dans les logs de production", UserIntent.AnalyzeLogs)]
        [InlineData("Voici un ticket qui est remonté.", UserIntent.AnalyzeTicket)]
        [InlineData("", UserIntent.Unknown)]
        [InlineData(" ", UserIntent.Unknown)]
        [InlineData("Je ne comprends pas ce qui se passe", UserIntent.ClarifyRequest)]
        public void Analyze_WhenInputIsEvaluated_ReturnsExpectedIntent(string userInput, UserIntent expectedIntent)
        {
            //Arrange
            var analyzer = new SimpleIntentAnalyzer();

            //Act
            var result = analyzer.Analyze(userInput);

            //Assert
            Assert.Equal(expectedIntent, result);
        }
    }
}