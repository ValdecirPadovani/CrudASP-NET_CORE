using System.Collections.Generic;
using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Model;
using CrudASP_NET_CORE.Repository;
using CrudASP_NET_CORE.Repository.Generic;

namespace CrudASP_NET_CORE.Buseness.Implementations
{
    public class BookBusenessImpl : IBookBuseness
    {

        private IRepository<Book> _repository;

        public BookBusenessImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindByI(long id)
        {
            return _repository.FindByI(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
