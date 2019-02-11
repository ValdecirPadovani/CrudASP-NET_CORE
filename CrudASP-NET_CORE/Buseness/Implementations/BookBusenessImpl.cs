using System.Collections.Generic;
using CrudASP_NET_CORE.Controllers.Data.Converters;
using CrudASP_NET_CORE.Controllers.Data.VO;
using CrudASP_NET_CORE.Model;
using CrudASP_NET_CORE.Repository.Generic;

namespace CrudASP_NET_CORE.Buseness.Implementations
{
    public class BookBusenessImpl : IBookBuseness
    {

        private IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusenessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindByI(long id)
        {
            return _converter.Parse(_repository.FindByI(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookUpdate = _converter.Parse(book);
            bookUpdate = _repository.Update(bookUpdate);
            return _converter.Parse(bookUpdate);
        }
    }
}
