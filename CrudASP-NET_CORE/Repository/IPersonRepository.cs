using CrudASP_NET_CORE.Controllers.Model;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByI(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

        bool Exist(long? id);
    }
}
