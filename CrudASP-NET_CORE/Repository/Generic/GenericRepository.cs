using CrudASP_NET_CORE.Controllers.Model.Context;
using CrudASP_NET_CORE.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudASP_NET_CORE.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MySQLContext _mySQLContext;
        private DbSet<T> dataSet;

        public GenericRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
            dataSet = _mySQLContext.Set<T>();
        }

        public T Create(T Item)
        {
            try
            {
                dataSet.Add(Item);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;  
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null) dataSet.Remove(result);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindByI(long id)
        {
            return dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T Item)
        {
            if (!Exist(Item.Id)) return null;

            var result = dataSet.SingleOrDefault(p => p.Id.Equals(Item.Id));
            try
            {
                _mySQLContext.Entry(result).CurrentValues.SetValues(Item);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }
    }
}
