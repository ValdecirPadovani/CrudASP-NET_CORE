using System;
using System.Collections.Generic;
using System.Threading;
using CrudASP_NET_CORE.Controllers.Model;

namespace CrudASP_NET_CORE.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindByI(long id)
        {
            return new Person
            {
                id = 1,
                FirstName = "Primeiro nome ",
                LastName = "Ultimo nome ",
                Address = "Endereço",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }


        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                id = IncrementAndGet(),
                FirstName = "Primeiro nome " + i,
                LastName = "Ultimo nome " + i,
                Address = "Endereço" + i,
                Gender = "Masculino" + i
            };
        }
    }
}
