using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Core;

namespace Tadbir.Domain.Cofiguration
{
    public class RabbitMqConfiguration: IMessageBrokerSettings
    {
        public RabbitMqConfiguration()
        {
            var configuration =AppSettingHelper. GetConfigurationFromJson();
            configuration.GetSection("RabbitMqConfiguration").Bind(this);
        }
       
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
