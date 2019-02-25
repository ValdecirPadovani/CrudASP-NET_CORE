using CrudASP_NET_CORE.Controllers.Data.VO;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Buseness
{
    public interface IPersonBuseness
    {
        PersonVO Create(PersonVO personVO);
        PersonVO FindByI(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string nome, string sobreNome);
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
