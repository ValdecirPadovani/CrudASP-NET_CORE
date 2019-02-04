using CrudASP_NET_CORE.Buseness;
using CrudASP_NET_CORE.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudASP_NET_CORE.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksControler : ControllerBase
    {

        private IBookBuseness _bookBusenes;

        public BooksControler (IBookBuseness bookBuseness)
        {
            _bookBusenes = bookBuseness;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusenes.FindAll());
        }

        // GET api/values/5
        [HttpGet("v1/{id}")]
        public ActionResult Get(long id)
        {
            //var person = _bookBusinees.FindByI(id);
            //if (person == null) return NotFound();
            //return Ok(person);
            return Ok();
        }

        // POST api/values
        [HttpPost("v1")]
        public ActionResult Post([FromBody] Book book)
        {
            //if (person == null) return BadRequest();
            //return new ObjectResult(_bookBusinees.Create(person));
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("v1/{id}")]
        public ActionResult Put([FromBody] Book book)
        {
            //if (person == null) return BadRequest();
            //var updatePerson = _bookBusinees.Update(person);
            //if (updatePerson == null) return NoContent();
            //return new ObjectResult(_bookBusinees.Update(person));

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("v1/{id}")]
        public ActionResult Delete(int id)
        {
            //_bookBusinees.Delete(id);
            //return NoContent();
            return Ok();
        }
    }
}
