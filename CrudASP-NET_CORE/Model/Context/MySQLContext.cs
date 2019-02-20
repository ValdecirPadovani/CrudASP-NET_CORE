using CrudASP_NET_CORE.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudASP_NET_CORE.Controllers.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        
        public DbSet<Person> Persons    { get; set; }
        public DbSet<Book> Books        { get; set; }
        public DbSet<Users> Users       { get; set; } 

    }
}
