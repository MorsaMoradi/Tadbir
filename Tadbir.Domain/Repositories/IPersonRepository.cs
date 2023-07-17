using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Domain;

namespace Tadbir.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task InsertAsync(Person domain);
        Task UpdateAsync(Person domain);
    }
}
