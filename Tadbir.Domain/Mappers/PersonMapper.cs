using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Domain.Core;
using Tadbir.Domain.Domain;
using Tadbir.Domain.Dto;

namespace Tadbir.Domain.Mappers
{
    public class PersonMapper : IEntityMapper<Person, PersonDto>
    {
        public Person MapFrom(PersonDto dto) 
            => new Person(dto.Id, dto.FirstName, dto.LastName, dto.Age);

        public PersonDto MapTo(Person domain) 
            => new PersonDto(domain.Id, domain.FirstName, domain.LastName, domain.Age);
    }
}
