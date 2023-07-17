using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Domain.Domain
{
    public class Person
    {
        public Person(Guid id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        protected Person()
        {
            
        }
        public Guid Id{ get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int Age { get; protected set; }

        public void SetId(Guid id)=>Id= id;
    }
}
