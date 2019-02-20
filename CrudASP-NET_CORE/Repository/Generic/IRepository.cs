using CrudASP_NET_CORE.Model.Base;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T Item);
        T FindByI(long id);
        List<T> FindAll();
        T Update(T Item);
        void Delete(long id);
        bool Exist(long? id);
    }
}
