using System.Linq;
using CrudASP_NET_CORE.Controllers.Model.Context;
using CrudASP_NET_CORE.Model;

namespace CrudASP_NET_CORE.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {

        private MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Users FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.login.Equals(login));
        }
    }
}
