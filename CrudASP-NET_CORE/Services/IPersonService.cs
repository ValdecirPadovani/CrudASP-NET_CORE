using CrudASP_NET_CORE.Controllers.Model;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByI(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
