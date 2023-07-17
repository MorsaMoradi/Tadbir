using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Core;
using Tadbir.Domain.Domain;

namespace Tadbir.Domain.Consumer
{
    public interface IPersonConsumerService : IConsumerService<Person>
    {
    }
}
