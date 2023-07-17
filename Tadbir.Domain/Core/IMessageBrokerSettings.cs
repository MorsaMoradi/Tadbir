namespace Tadbir.Domain.Core
{
    public interface IMessageBrokerSettings
    {
        string HostName { get; }
        string Username { get; }
        string Password { get; }
    }
}
