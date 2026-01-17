namespace AssistantIT.Console.Support;

public class SupportService
{
    public string HandleTicket(string description)
    {
        return "Ticket reçu. Une analyse de premier niveau sera effectuée.";
    }

    public string HandleLogs(string logs)
    {
        return "Logs reçus. Analyse préliminaire en cours.";
    }
}
