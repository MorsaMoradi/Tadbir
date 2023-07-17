using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Core;
using Tadbir.Domain.Domain;
using Tadbir.Domain.Dto;

namespace Tadbir.Domain.Service
{
    public interface IPersonService : IHandelMessage<PersonDto>
    {
        Task<PersonDto> SaveAsync(PersonDto person);
    }
}
