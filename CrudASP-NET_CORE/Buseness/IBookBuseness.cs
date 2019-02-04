using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Model;
using CrudASP_NET_CORE.Model.Base;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Buseness
{
    public interface IBookBuseness 
    {
        Book Create(Book person);
        Book FindByI(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}
