using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Controllers.Model.Context;
using CrudASP_NET_CORE.Repository;

namespace CrudASP_NET_CORE.Buseness.Implementations
{
    public class PersonBusenessImpl : IPersonBuseness
    {

        private IPersonRepository _repository;

        public PersonBusenessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByI(long id)
        {
            return _repository.FindByI(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
