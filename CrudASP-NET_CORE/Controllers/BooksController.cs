using CrudASP_NET_CORE.Buseness;
using Microsoft.AspNetCore.Mvc;
using CrudASP_NET_CORE.Controllers.Data.VO;
using Tapioca.HATEOAS;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_bookBusenes.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public ActionResult Get(long id)
        {
            var book = _bookBusenes.FindByI(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusenes.Create(book));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType((202), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            var updateBook = _bookBusenes.Update(book);
            if (updateBook == null) return NoContent();
            return new ObjectResult(_bookBusenes.Update(book));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(int id)
        {
            _bookBusenes.Delete(id);
            return NoContent();
        }
    }
}
