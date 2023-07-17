using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Cofiguration;
using Tadbir.Domain.Consumer;
using Tadbir.Domain.Core;
using Tadbir.Domain.Domain;
using Tadbir.Domain.Dto;
using Tadbir.Domain.Service;
using Tadbir.RabbitMq.Common;
using Tadbir.Service.Services;

namespace Tadbir.Service.Consumer
{
    public class PersonConsumerService : ConsumerService<PersonDto>, IPersonConsumerService
    {

        public PersonConsumerService(IPersonService handler, IMessageBrokerSettings messageBrokerSettings, ILogger<PersonConsumerService> logger)
            : base(handler, QueueConst.PersonQueue, messageBrokerSettings,logger)
        {
        }
    }
}
