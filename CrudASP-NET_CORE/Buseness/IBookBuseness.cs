using CrudASP_NET_CORE.Controllers.Data.VO;
using CrudASP_NET_CORE.Model;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Buseness
{
    public interface IBookBuseness 
    {
        BookVO Create(BookVO person);
        BookVO FindByI(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO person);
        void Delete(long id);
    }
}
