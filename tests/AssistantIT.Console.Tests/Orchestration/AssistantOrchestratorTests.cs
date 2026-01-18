using AssistantIT.Console.Orchestration;
using AssistantIT.Console.Support;
using AssistantIT.Console.Models;
using AssistantIT.Console.Tests.Fakes;
using Xunit;

namespace AssistantIT.Console.Tests.Orchestration
{
    public class AssistantOrchestratorTests
    {
        [Fact]
        public void HandleUserInput_WhenIntentIsAnalyzeTicket_ReturnsTicketResponse()
        {
            //Arrange
            var fakeIntentAnalyzer = new FakeIntentAnalyzer(UserIntent.AnalyzeTicket);
            var supportService = new SupportService();
            var userInput = "N'importe quoi.";

            var orchestrator = new AssistantOrchestrator(fakeIntentAnalyzer, supportService);
            var expectedResponse = "Ticket reçu. Une analyse de premier niveau sera effectuée.";

            //Act
            var result = orchestrator.HandleUserInput(userInput);

            //Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void HandleUserInput_WhenIntentIsAnalyzeLogs_ReturnsLogResponse()
        {
            //Arrange
            var fakeIntentAnalyzer = new FakeIntentAnalyzer(UserIntent.AnalyzeLogs);
            var supportService = new SupportService();
            var userInput = "N'importe quoi.";

            var orchestrator = new AssistantOrchestrator(fakeIntentAnalyzer, supportService);
            var expectedResponse = "Logs reçus. Analyse préliminaire en cours.";

            //Act
            var result = orchestrator.HandleUserInput(userInput);

            //Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void HandleUserInput_WhenIntentIsClarifyRequest_ReturnsClarificationMessage ()
        {
            //Arrange
            var fakeIntentAnalyzer = new FakeIntentAnalyzer(UserIntent.ClarifyRequest);
            var supportService = new SupportService();
            var userInput = "N'importe quoi.";

            var orchestrator = new AssistantOrchestrator(fakeIntentAnalyzer, supportService);
            var expectedResponse = "Peux-tu préciser ton problème ou fournir plus de détails ?";

            //Act
            var result = orchestrator.HandleUserInput(userInput);

            //Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}