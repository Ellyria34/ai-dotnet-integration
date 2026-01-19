using AssistantIT.Console.Intent;
using AssistantIT.Console.Models;

namespace AssistantIT.Console.Tests.Fakes
{
    public class FakeIntentAnalyzer : IIntentAnalyzer
    {
        private readonly UserIntent _intentToReturn;

        public FakeIntentAnalyzer(UserIntent intentToReturn)
        {
            _intentToReturn = intentToReturn;
        }

        public Task<UserIntent> AnalyzeAsync (string userInput)
        {
            return Task.FromResult(_intentToReturn);
        }
    }
}