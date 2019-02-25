using CrudASP_NET_CORE.Controllers.Model;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Repository.Generic
{
    public interface IPersonRepository<T> : IRepository<Person>
    {
        List<Person> FindByName(string nome, string sobreNome);
    }
}
