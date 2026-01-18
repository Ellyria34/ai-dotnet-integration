using System.Reflection;
using AssistantIT.Console.Support;
using Xunit;

namespace AssistantIT.Console.Tests.Support
{
    public class SupportServiceTests
    {
        private readonly SupportService _supportService;

        public SupportServiceTests()
        {
            _supportService = new SupportService();
        }

        [Fact]
        public void HandleTicket_ReturnsConfirmationMessage()
        {
            //Arrange
            var description = "Problème de connexion signalé par l'utilisateur";
            var expectedResponse = "Ticket reçu. Une analyse de premier niveau sera effectuée.";
            
            //Act
            var result = _supportService.HandleTicket(description);

            //Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void HandleLogs_ReturnsConfirmationMessage()
        {
            //Arrange
            var description = "list des logs";
            var expectedResponse = "Logs reçus. Analyse préliminaire en cours.";
            
            //Act
            var result = _supportService.HandleLogs(description);

            //Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
