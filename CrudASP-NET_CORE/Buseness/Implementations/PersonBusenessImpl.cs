using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CrudASP_NET_CORE.Controllers.Data.Converters;
using CrudASP_NET_CORE.Controllers.Data.VO;
using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Controllers.Model.Context;
using CrudASP_NET_CORE.Repository;
using CrudASP_NET_CORE.Repository.Generic;

namespace CrudASP_NET_CORE.Buseness.Implementations
{
    public class PersonBusenessImpl : IPersonBuseness
    {

        private IRepository<Person> _repository;

        private readonly PersonConverter _personConverters;

        public PersonBusenessImpl(IRepository<Person> repository)
        {
            _repository = repository;
            _personConverters = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _personConverters.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _personConverters.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _personConverters.ParseList(_repository.FindAll());
        }

        public PersonVO FindByI(long id)
        {
            return _personConverters.Parse(_repository.FindByI(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _personConverters.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _personConverters.Parse(personEntity);
        }
    }
}
