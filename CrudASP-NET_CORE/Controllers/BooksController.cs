using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Buseness;
using Microsoft.AspNetCore.Mvc;
using CrudASP_NET_CORE.Model;

namespace CrudASP_NET_CORE.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {

        private IBookBuseness _bookBusenes;

        public BooksController (IBookBuseness bookBuseness)
        {
            _bookBusenes = bookBuseness ?? throw new System.ArgumentNullException(nameof(bookBuseness));
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusenes.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var book = _bookBusenes.FindByI(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusenes.Create(book));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            var updateBook = _bookBusenes.Update(book);
            if (updateBook == null) return NoContent();
            return new ObjectResult(_bookBusenes.Update(book));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bookBusenes.Delete(id);
            return NoContent();
        }
    }
}
