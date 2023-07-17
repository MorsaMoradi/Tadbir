using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Domain.Dto
{
    public class PersonDto
    {
        public PersonDto(Guid id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        
        public Guid Id { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public int Age { get;  set; }
    }
}
