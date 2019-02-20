using CrudASP_NET_CORE.Model;

namespace CrudASP_NET_CORE.Buseness
{
    public interface ILoginBuseness
    {
        object FindByLogin(Users user);
    }
}
