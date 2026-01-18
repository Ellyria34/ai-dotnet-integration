using System.Reflection;
using AssistantIT.Console.Support;
using Xunit;

namespace AssistantIT.Console.Tests.Support
{
    public class SupportServiceTests
    {
        [Fact]
        public void HandleTicket_ReturnsConfirmationMessage()
        {
            //Arrange
            var support = new SupportService();
            var description = "Problème de connexion signalé par l'utilisateur";
            var expectedResponse = "Ticket reçu. Une analyse de premier niveau sera effectuée.";
            
            //Act
            var result = support.HandleTicket(description);

            //Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void HandleLogs_ReturnsConfirmationMessage()
        {
            //Arrange
            var support = new SupportService();
            var description = "list des logs";
            var expectedResponse = "Logs reçus. Analyse préliminaire en cours.";
            
            //Act
            var result = support.HandleLogs(description);

            //Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
