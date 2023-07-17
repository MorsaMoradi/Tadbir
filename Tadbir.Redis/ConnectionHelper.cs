using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using Tadbir.Domain.Cofiguration;
using Tadbir.Domain.Core;

namespace Tadbir.Redis
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            IRedisSettings settings = new RedisAppSettings();
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(settings.RedisURL);
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}