using CrudASP_NET_CORE.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
