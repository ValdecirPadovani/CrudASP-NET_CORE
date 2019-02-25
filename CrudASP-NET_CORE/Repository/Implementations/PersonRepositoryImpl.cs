using System.Linq;
using CrudASP_NET_CORE.Controllers.Model.Context;
using CrudASP_NET_CORE.Model;
using CrudASP_NET_CORE.Repository.Generic;

namespace CrudASP_NET_CORE.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Users FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.login.Equals(login));
        }
    }
}
