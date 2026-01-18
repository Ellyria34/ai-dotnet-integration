using AssistantIT.Console.Orchestration;
using AssistantIT.Console.Support;
using AssistantIT.Console.Models;
using AssistantIT.Console.Tests.Fakes;
using Xunit;

namespace AssistantIT.Console.Tests.Orcherstration
{
    public class AssistantOrchestratorTests
    {
        [Fact]
        public void HandleUserInput_ReturnResponse()
        {
            //Arrange
            var fakeIntentAnalyzer = new FakeIntentAnalyzer(UserIntent.AnalyzeTicket);
            var supportService = new SupportService();
            var userInput = "N'importe quoi.";

            var orchestrator = new AssistantOrchestrator(fakeIntentAnalyzer, supportService);
            var expectedResponse = "Ticket reçu. Une analyse de premier niveau sera effectuée.";

            //Act
            var result = orchestrator.HandleUserInput(userInput);

            //Asssert
            Assert.Equal(expectedResponse, result);
        }
    }
}