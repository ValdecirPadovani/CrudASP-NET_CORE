using System.Collections.Generic;
using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudASP_NET_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {

        private IPersonService _ipersonService;

        public PersonsController(IPersonService ipersonService) => _ipersonService = ipersonService;

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_ipersonService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _ipersonService.FindByI(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_ipersonService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_ipersonService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _ipersonService.Delete(id);
            return NoContent();
        }
    }
}
