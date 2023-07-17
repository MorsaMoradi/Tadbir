using Tadbir.Domain.Cofiguration;

namespace Tadbir.Domain.Core
{
    public interface IAppSettings
    {
        RabbitMqConfiguration RabbitMqConfiguration { get; }
    }
}
