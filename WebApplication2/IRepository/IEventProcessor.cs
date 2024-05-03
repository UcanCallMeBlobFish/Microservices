namespace WebApplication2.IRepository
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);

    }
}
