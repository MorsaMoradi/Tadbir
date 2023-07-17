using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Tadbir.Domain.Cofiguration;
using Tadbir.Domain.Core;
using Tadbir.Domain.Service;

namespace Tadbir.RabbitMq.Common
{
    public abstract class ConsumerService<T> : IConsumerService<T>, IDisposable where T : class
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        private readonly IHandelMessage<T> _handler;
        private readonly ILogger<ConsumerService<T>> _logger;

        public string QueueName { set; get; }

        public IMessageBrokerSettings messageBrokerSettings { set; get; }

        public ConsumerService(IHandelMessage<T> handler, string queueName, IMessageBrokerSettings messageBrokerSettings, ILogger<ConsumerService<T>> logger)
        {
            _handler = handler;
            _connection = new RabbitMqService().CreateChannel(messageBrokerSettings);
            _model = _connection.CreateModel();
            QueueName = queueName;
            this.messageBrokerSettings = messageBrokerSettings;
            _logger = logger;
        }
        public async Task Listen()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                //must log
                var text = System.Text.Encoding.UTF8.GetString(body);
                _logger.LogInformation("Read data from {0} : {1}",QueueName,text);
                var temp = JsonConvert.DeserializeObject<T>(text);
                var reuslt = await _handler.AfterReadMessageAsync(temp);

                if (reuslt)
                    _model.BasicAck(ea.DeliveryTag, false);
                throw new Exception("Error in Save data");

                await Task.CompletedTask;
            };
            _model.BasicConsume(QueueName, false, consumer);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();
            if (_connection.IsOpen)
                _connection.Close();
        }
    }
}
