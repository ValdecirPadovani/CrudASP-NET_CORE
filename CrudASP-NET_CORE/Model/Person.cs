using CrudASP_NET_CORE.Model.Base;

namespace CrudASP_NET_CORE.Controllers.Model
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
