using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Domain.Core
{
    public interface IEntityMapper<Tdomain,TdomainDto>
    {
        Tdomain MapFrom(TdomainDto dto);
        TdomainDto MapTo(Tdomain domain);
    }
}
