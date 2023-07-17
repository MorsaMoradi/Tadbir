using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Core;

namespace Tadbir.Domain.Cofiguration
{
    public class RedisAppSettings : IRedisSettings
    {
        public string RedisURL { set; get; }
        public RedisAppSettings()
        {
            var configuration = AppSettingHelper.GetConfigurationFromJson();
            configuration.GetSection("RedisConfiguration").Bind(this);
        }
    }
}
