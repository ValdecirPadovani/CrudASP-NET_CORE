using CrudASP_NET_CORE.Buseness;
using Microsoft.AspNetCore.Mvc;
using CrudASP_NET_CORE.Controllers.Data.VO;
using Tapioca.HATEOAS;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CrudASP_NET_CORE.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {

        private IPersonBuseness _ipersonBuseness;

        public PersonsController(IPersonBuseness ipersonBuseness) => _ipersonBuseness = ipersonBuseness;

        // GET api/values
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public ActionResult Get()
        {
            return Ok(_ipersonBuseness.FindAll());
        }

        // GET api/values
        [HttpGet("find-by-name")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public ActionResult GetByName([FromQuery] string nome, [FromQuery] string sobreNome)
        {
            return new OkObjectResult(_ipersonBuseness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type=typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public ActionResult Get(int id)
        {
            var person = _ipersonBuseness.FindByI(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_ipersonBuseness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType((202), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _ipersonBuseness.Update(person);
            if (updatePerson == null) return NoContent();
            return new ObjectResult(_ipersonBuseness.Update(person));
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
            _ipersonBuseness.Delete(id);
            return NoContent();
        }
    }
}
