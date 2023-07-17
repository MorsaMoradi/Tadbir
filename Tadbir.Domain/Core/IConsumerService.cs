namespace Tadbir.Domain.Core
{

    public interface IConsumerService<T> where T : class
    {
        string QueueName { get; }
        IMessageBrokerSettings messageBrokerSettings { get; }
        Task Listen();
    }
}
