namespace AssistantIT.Console.Observability;
public interface IIntentObserver
{
    void Observe(AiIntentAnalysis analysis);
}
