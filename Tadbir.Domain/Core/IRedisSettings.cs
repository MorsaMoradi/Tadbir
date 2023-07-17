using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Domain.Core
{
    public  interface IRedisSettings
    {
        string RedisURL { get; }
    }
}
