using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Model;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Repository
{
    public interface IUserRepository
    {
        Users FindByLogin(string login);
    }
}
