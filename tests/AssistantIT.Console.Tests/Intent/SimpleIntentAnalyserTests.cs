using System.Reflection;
using AssistantIT.Console.Intent;
using AssistantIT.Console.Models;
using Xunit;

namespace AssistantIT.Console.Tests.Intent
{
    public class SimpleIntentAnalyzerTests
    {
        [Fact]
        public void Analyze_WhenInputContainsLog_ReturnsAnalyzeLogs()
        {
            // Arrange
            var Analyzer = new SimpleIntentAnalyzer();
            var userInput = "Erreur détectéé dans les logs de production";
            
            // Act
            var result = Analyzer.Analyze(userInput);
        
            // Assert
            Assert.Equal(UserIntent.AnalyzeLogs, result);
        }

        [Fact]
        public void Analyze_WhenInputContainTicket_ReturnAnalyzeTicket()
        {
            //Arrange
            var analyzer = new SimpleIntentAnalyzer();
            var userInput = "Voici un ticket qui est remonté.";

            //Act
            var result = analyzer.Analyze(userInput);

            //Assert
            Assert.Equal(UserIntent.AnalyzeTicket, result);
        }
    }
}